using MyChatDB.iron_python.engine;
using MyChatDB.src.util;
using MyChatDB.src.windows.inspectors;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyChatDB.src.services
{
    internal class GuiService
    {
        static GuiService _instance;
        Engine _engine;

        static GuiService getInstance()
        {
            if (_instance == null)
            {
                _instance = new GuiService();
            }
            return _instance;
        }

        GuiService()
        {
            _engine = Engine.GetInstance();
        }

        public static string Perform(string command, string jsonArg)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(jsonArg);
            switch (command.ToLower())
            {
                case "inspect":
                    getInstance().Inspect(value);
                    return "OK";
                default:
                    return @"UNKNOWN COMMAND ${command}";
            }
        }

        void Inspect(object value)
        {
            var type = value.GetType();
            switch (type.Name.ToLower())
            {
                case "boolean":
                    openBooleanInspector((bool)value);
                    break;
                case "int64":
                case "double":
                    openNumberInspector(value);
                    break;
                case "jarray":
                    openListInspector((JArray)value);
                    break;
                case "jobject":
                    openObjectInspector((JObject)value);
                    break;
                case "string":
                    openTextInspector((string)value);
                    break;
                default:
                    getInstance()._engine.PrintLn($"TYPE: {type.Name}");
                    break;
            }
        }

        void openBooleanInspector(bool value)
        {
            TranscriptWindow.OpenBooleanInspector(value);
        }

        void openListInspector(JArray jArray)
        {
            TranscriptWindow.OpenListInspector(NormalizeJson.NormalizeJArray(jArray));
        }

        void openNumberInspector(object value)
        {
            TranscriptWindow.OpenNumberInspector(value);
        }

        void openObjectInspector(JObject jObject)
        {
            TranscriptWindow.OpenObjectInspector(NormalizeJson.NormalizeJObject(jObject));
        }

        void openTextInspector(string value)
        {
            TranscriptWindow.OpenTextInspector(value);
        }

    }
}
