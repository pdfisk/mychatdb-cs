namespace MyChatDB.core.iron_python
{
    public class Engine
    {
        public static readonly Engine Instance = new Engine();

        private Engine() {
            System.Console.WriteLine("Engine initialized.");
        }
    }
}
