namespace ActionAndFuncDelegatesInCSharp.Func
{
    public static class FuncMethod
    {
        public static string GetValueFromFuncLambda()
        {
            // Func delegate with lambda expression
            Func<string[], string> stringConnecterFunc = x =>
            {
                return string.Join(" ", x);
            };
            return stringConnecterFunc(new string[] { "I", "Love", "C#", "using Func", "with Lambda Expression" });
        }

        // Method
        public static string StringConnectorMethod(string s1, string s2, string s3, string s4)
        {
            return string.Join(" ", s1, s2, s3, s4);
        }
        public static string GetValueFromFunc()
        {
            // Creating string with Func
            Func<string, string, string, string, string> stringConnectorFunc = StringConnectorMethod;
            return stringConnectorFunc("I", "Love", "C#", "using Func");
        }
    }
}
