namespace ActionAndFuncDelegatesInCSharp
{
    public class FuncExampleOne
    {
        public Func<string> welcomeUser;
        public FuncExampleOne()
        {
            welcomeUser = DisplayWelcomeMessageToUser;
            welcomeUser(); //This outputs: Hello! Welcome to a new day
        }

        public string DisplayWelcomeMessageToUser()
        {
            return "Hello! Welcome to a new day";
        }
    }
}