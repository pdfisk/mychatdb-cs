using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyChatDB.core.iron_python
{
    public class Engine
    {
        static Engine Instance;
        Transcript transcript;
        private readonly ScriptEngine _engine;
        private readonly ScriptScope _scope;

        public static Engine GetInstance(Transcript transcript = null)
        {
            if (transcript != null)
            {
                Instance = new Engine();
                Instance.transcript = transcript;
            }
            return Instance;
        }

        private Engine()
        {
            _engine = Python.CreateEngine();
            _scope = _engine.CreateScope();

        }
        public void LoadScript(string filePath)
        {
            _engine.ExecuteFile(filePath, _scope);
        }

        public async Task<object> CallFunctionAsync(string functionName, string jsonArgs)
        {
            return await Task.Run(() =>
            {
                if (!_scope.ContainsVariable(functionName))
                    throw new MissingMemberException($"Function '{functionName}' not found in the Python script.");

                dynamic pyFunc = _scope.GetVariable(functionName);

                object argsObj = JsonConvert.DeserializeObject(jsonArgs);

                if (argsObj is JArray arr)
                {
                    var argsList = arr.ToObject<object[]>();
                    return pyFunc.__call__(argsList);
                }
                else if (argsObj is JObject obj)
                {
                    var dict = obj.ToObject<Dictionary<string, object>>();
                    return pyFunc.__call__(dict);
                }

                throw new ArgumentException("Invalid JSON argument format. Must be an array or object.");
            });
        }

        public async Task<object> ExecuteAsync(string code, string jsonLocals = null)
        {
            return await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(jsonLocals))
                {
                    var locals = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonLocals);
                    foreach (var kvp in locals)
                        _scope.SetVariable(kvp.Key, kvp.Value);
                }

                return _engine.Execute(code, _scope);
            });
        }

        public void ExecuteScript(string script = "print(3+4)")
        {
            transcript.PrintLn($"Executing script: {script}");
        }
    }
}
