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

        public static string Perform(string command, string jsonArg)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(jsonArg);
            switch (command.ToLower())
            {
                case "parse_cobol":
                   return getInstance().ParseCobol(value.ToString());
                default:
                    return @"UNKNOWN COMMAND ${command}";
            }
        }

        string ParseCobol(string fileName)
        {
            return fileName.ToUpper();
        }
    }
}
