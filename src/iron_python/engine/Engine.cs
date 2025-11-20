using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using MyChatDB.src.iron_python.engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MyChatDB.src.constants;
using MyChatDB.src.services;

namespace MyChatDB.iron_python.engine
{
    public class Engine
    {
        static Engine Instance = null;
        IResultHandler _resultHandler;
        private bool _running = false;
        private readonly ScriptEngine _engine;
        private readonly GlobalAccessor _globalAccessor;
        private readonly Dictionary<string, object> _sharedGlobalsDictionary;
        private readonly ScriptScope _scope;
        private readonly MemoryStream _stdoutStream;
        private readonly MemoryStream _stderrStream;
        private readonly StreamWriter _stdoutWriter;
        private readonly StreamWriter _stderrWriter;

        public static Engine GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Engine();
                Instance._resultHandler = TranscriptWindow.GetInstance(Instance);
                Instance.LoadScript("services");
            }
            return Instance;
        }

        private Engine()
        {
            var baseDir = "C:/Program Files/IronPython 3.4/";
            var paths = new string[]
            {baseDir,
                $"{baseDir}/DLL",
                $"{baseDir}/Lib",
                $"{baseDir}/Lib/site-packages"
           };
            _engine = Python.CreateEngine();
            _scope = _engine.CreateScope();
            _globalAccessor = new GlobalAccessor(_engine, _scope);
            _sharedGlobalsDictionary = new Dictionary<string, object>();
            _stdoutStream = new MemoryStream();
            _stderrStream = new MemoryStream();
            _stdoutWriter = new StreamWriter(_stdoutStream) { AutoFlush = true };
            _stderrWriter = new StreamWriter(_stderrStream) { AutoFlush = true };
            _engine.SetSearchPaths(paths);
            _engine.Runtime.IO.SetOutput(_stdoutStream, _stdoutWriter);
            _engine.Runtime.IO.SetErrorOutput(_stderrStream, _stderrWriter);
        }

        /// <summary>
        /// Loads a Python script into the current IronPython scope.
        /// </summary>
        public void LoadScript(string filePath)
        {
            if (!filePath.EndsWith(".py"))
                filePath += ".py";
            var scriptsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts");
            var fullPath = Path.Combine(scriptsPath, filePath);
            var exists = File.Exists(fullPath);
            PrintLn($"Loading script from: {fullPath} {exists}");
            if (File.Exists(fullPath))
                _engine.ExecuteFile(fullPath, _scope);
        }

        /// <summary>
        /// Executes a Python function asynchronously, with JSON arguments.
        /// Supports positional (array) or keyword (object) arguments.
        /// </summary>
        public async Task<(object result, string stdout, string stderr)> CallFunctionAsync(
            string functionName,
            string jsonArgs,
            CancellationToken cancellationToken = default)
        {
            if (_running)
                return (null, "", "");
            _running = true;

            return await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                ResetStreams();

                if (!_scope.ContainsVariable(functionName))
                    throw new MissingMemberException($"Function '{functionName}' not found in the Python script.");

                dynamic pyFunc = _scope.GetVariable(functionName);

                object argsObj = JsonConvert.DeserializeObject(jsonArgs);

                object result;

                if (argsObj is JArray arr)
                {
                    var argsList = arr.ToObject<object[]>();
                    result = pyFunc.__call__(argsList);
                }
                else if (argsObj is JObject obj)
                {
                    var dict = obj.ToObject<Dictionary<string, object>>();
                    result = pyFunc.__call__(dict);
                }
                else
                {
                    throw new ArgumentException("Invalid JSON argument format. Must be an array or object.");
                }

                cancellationToken.ThrowIfCancellationRequested();

                _running = false;
                return (result, GetStdOut(), GetStdErr());
            }, cancellationToken);
        }

        public async void RunScript(string code, IResultHandler resultHandler = null)
        {
            if (_running) return;
            Func<string, string, string> gui_service = (method, args) => { return GuiService.Perform(method, args); };
            Func<string, string, string> parser_service = (method, args) => { return ParserService.Perform(method, args); };
            _running = true;
            _globalAccessor.SetGlobal(SharedConstants.SHARED_GLOBALS, _sharedGlobalsDictionary);
            _globalAccessor.SetGlobal(SharedConstants.GUI_SERVICE, gui_service);
            _globalAccessor.SetGlobal(SharedConstants.PARSER_SERVICE, parser_service);
            Task<(object result, string stdout, string stderr)> task = ExecuteAsync(code);
            await task;
            _running = false;
            ResultObject resultObject = new ResultObject(task.Result.result, task.Result.stdout, task.Result.stderr);
            if (resultHandler != null)
            {
                resultHandler.HandleResult(resultObject);
            }
        }

        /// <summary>
        /// Executes arbitrary Python code asynchronously with optional JSON locals.
        /// </summary>
        public async Task<(object result, string stdout, string stderr)> ExecuteAsync(
            string code,
            string jsonLocals = null,
            CancellationToken cancellationToken = default)
        {
            return await Task.Run(() =>
           {
               cancellationToken.ThrowIfCancellationRequested();
               ResetStreams();

               if (!string.IsNullOrEmpty(jsonLocals))
               {
                   var locals = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonLocals);
                   foreach (var kvp in locals)
                       _scope.SetVariable(kvp.Key, kvp.Value);
               }

               var result = _engine.Execute(code, _scope);
               cancellationToken.ThrowIfCancellationRequested();
               var stdout = GetStdOut().TrimEnd();
               var stderr = GetStdErr().TrimEnd();
               return (result, stdout, stderr);
           }, cancellationToken);
        }

        public Dictionary<string, object> GetVariables()
        {
            var dict = new Dictionary<string, object>();
            var enumerator = _scope.GetVariableNames().GetEnumerator();
            while (enumerator.MoveNext())
            {
                var name = enumerator.Current;
                var value = _scope.GetVariable(name);
                dict[name] = value;
            }
            return dict;
        }

        /// <summary>
        /// Reads captured Python standard output.
        /// </summary>
        public string GetStdOut()
        {
            _stdoutWriter.Flush();
            _stdoutStream.Position = 0;
            var reader = new StreamReader(_stdoutStream, System.Text.Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);
            string output = reader.ReadToEnd();
            _stdoutStream.Position = _stdoutStream.Length;
            return output;
        }

        /// <summary>
        /// Reads captured Python error output.
        /// </summary>
        public string GetStdErr()
        {
            _stderrWriter.Flush();
            _stderrStream.Position = 0;
            var reader = new StreamReader(_stderrStream, System.Text.Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);
            string output = reader.ReadToEnd();
            _stderrStream.Position = _stderrStream.Length;
            return output;
        }

        public void PrintLn(string text)
        {
            _resultHandler?.PrintLn(text);
        }

        private void ResetStreams()
        {
            _stdoutStream.SetLength(0);
            _stderrStream.SetLength(0);
        }

    }
}
