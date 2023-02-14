namespace ActionAndFuncDelegatesInCSharp.Action
{
    public static class ActionMethod
    {
        public static void GetValueFromActionLambda()
        {
            // Action delegate with lambda expression
            Action<string[]> stringConnecterAction = x =>
            {
                Console.WriteLine(string.Join(" ", x));
            };
            stringConnecterAction(new string[] { "I", "Love", "C#", "using Action", "with Lambda Expression" });
        }

        // Method
        public static void StringConnectorMethod(string s1, string s2, string s3, string s4)
        {
            Console.WriteLine(string.Join(" ", s1, s2, s3, s4));
        }
        public static void GetValueFromAction()
        {
            // Action delegate with lambda expression
            Action<string, string, string, string> stringConnectorAction = StringConnectorMethod;
            stringConnectorAction("I", "Love", "C#", "using Action");
        }
    }
}
