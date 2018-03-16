namespace FirstCoreApp
{
    public interface IGreeter
    {
        string getGreetingOfToday();
    }

    public class Greeter : IGreeter
    {
        public string getGreetingOfToday()
        {
            return "Greeting from Greeter.";
        }
    }
}