namespace MyChatDB.src.services
{
    internal class ParserService
    {
        static ParserService _instance;
        public static ParserService getInstance()
        {
            if (_instance == null)
            {
                _instance = new ParserService();
            }
            return _instance;
        }
    }
}
