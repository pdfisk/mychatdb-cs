using MyChatDB.iron_python.engine;

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

        public static string Perform(string command, string argument)
        {
            switch (command.ToLower())
            {
                case "inspect":
                    return getInstance().Inspect(argument);
                default:
                    return "UNKNOWN COMMAND";
            }
        }

        string Inspect(object value)
        {
            getInstance()._engine.PrintLn("INSPECT");
            return "OK";
        }

    }
}
