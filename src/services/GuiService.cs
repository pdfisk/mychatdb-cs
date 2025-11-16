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

        static public void Inspect(object value)
        {
            getInstance()._engine.PrintLn("INSPECT");
        }
 
    }
}
