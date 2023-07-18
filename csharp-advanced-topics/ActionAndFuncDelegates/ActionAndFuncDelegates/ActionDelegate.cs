namespace ActionAndFuncDelegates
{
    public class ActionDelegate
    {
        public static string updatedName = null;
        public static int updatedage = 0;
        private static readonly int ageMargin = 24;

        public static void LogPerson(string name, int age)
        {
            Console.WriteLine($"Name: {name}\nAge: {age}");
        }

        Action<string, int> actionWithLambda = (name, age) =>
        {
            updatedName = name.ToLower();
            updatedage = age + ageMargin;
        };

        public void ActionWithLambda(string name, int age) => actionWithLambda(name, age);

        Action<string, int> actionWithAnon = delegate (string name, int age)
        {
            updatedName = name.ToLower();
            updatedage = age + ageMargin;
        };

        public void ActionWithAnon(string name, int age) => actionWithAnon(name, age);
    }
}
