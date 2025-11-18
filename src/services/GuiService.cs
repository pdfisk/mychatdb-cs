using MyChatDB.iron_python.engine;
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
                    bool b = (bool)value;
                    new BooleanInspector(b);
                    break;
                case "int64":
                    long l = (long)value;
                    new NumberInspector(l);
                    break;
                case "double":
                    double d = (double)value;
                    new NumberInspector(d);
                    break;
                case "jarray":
                    JArray a = (JArray)value;
                    new ListInspector(a);
                    break;
                case "jobject":
                    JObject o = (JObject)value;
                    var dict = new Dictionary<string, object>();
                    openObjectInspector(dict);
                    break;
                case "string":
                    string s = (string)value;
                    new TextInspector(s);
                    break;
                default:
                    getInstance()._engine.PrintLn($"TYPE: {type.Name}");
                    break;
            }
        }

        void openObjectInspector(Dictionary<string, object> dict)
        {
            TranscriptWindow.OpenObjectInspector(dict);
        }

    }
}
