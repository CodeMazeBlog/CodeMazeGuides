namespace ActionAndFuncDelegates
{
    public class ActionDelegate
    {
        public static string? UpdatedName { get; set; }
        public static int UpdatedAge { get; set; }

        public static void LogPerson(string name, int age)
        {
            Console.WriteLine($"Name: {name}\nAge: {age}");
        }

        Action<string, int> actionWithLambda = (name, age) =>
        {
            UpdatedName = name.ToLower();
            UpdatedAge = age + 24;
        };

        public void ActionWithLambda(string name, int age) => actionWithLambda(name, age);


        Action<string, int> actionWithAnon = delegate (string name, int age)
        {
            UpdatedName = name.ToLower();
            UpdatedAge = age + 24;
        };

        public void ActionWithAnon(string name, int age) => actionWithAnon(name, age);
    }
}
