namespace MyChatDB.src.services
{
    internal class GuiService
    {
        static GuiService _instance;
        public static GuiService getInstance()
        {
            if (_instance == null)
            {
                _instance = new GuiService();
            }
            return _instance;
        }
    }
}
