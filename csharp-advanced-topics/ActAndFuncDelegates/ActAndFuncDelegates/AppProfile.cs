namespace ActAndFuncDelegates
{
    public enum Language
    {
        English,
        Spanish,
        French
    }
    public class User
    {
        public string Name { get; set; }
        public Language UserLanguage { get; set; }
    }

    public class AppProfile
    {
        private User _user;
        public AppProfile(User user)
        {
            _user = user;
        }
        private static void GreetingsEnglish(string userName) => Console.WriteLine($"Hello, {userName}");
        private static void GreetingsSpanish(string userName) => Console.WriteLine($"Hola, {userName}");
        private static void GreetingsFrench(string userName) => Console.WriteLine($"Bonjour, {userName}");

        public void GreetUser()
        {
            Action<string> greetingTarget;
            switch (_user.UserLanguage)
            {
                case Language.English:
                    greetingTarget = GreetingsEnglish;
                    break;
                case Language.Spanish:
                    greetingTarget = GreetingsSpanish;
                    break;
                case Language.French:
                    greetingTarget = GreetingsFrench;
                    break;
                default:
                    greetingTarget = GreetingsEnglish;
                    break;
            }
            greetingTarget(_user.Name);
        }
    }
}

