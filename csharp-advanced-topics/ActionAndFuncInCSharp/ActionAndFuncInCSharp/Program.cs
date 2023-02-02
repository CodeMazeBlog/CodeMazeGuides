namespace ActionAndFuncInCSharp
{
    public static class Program
    {
        public static void WriteText(string text) => Console.WriteLine($"Text: {text}");

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        public static void Main(string[] args)
        {
            // Action delegate assigned in different ways 

            Action<string> executeNamedAction = new Action<string>(WriteText);

            Action<string> executeNamedActionShorter = WriteText;

            Action<string> executeAnonymousAction
                = delegate (string text)
                {
                    Console.WriteLine($"Text: {text}");
                };

            Action<string> executeLambdaAction
                = text => Console.WriteLine($"Text: {text}");

            executeNamedAction("Action delegate in CSharp");
            executeNamedActionShorter("Action delegate in CSharp");
            executeAnonymousAction("Action delegate in CSharp");
            executeLambdaAction("Action delegate in CSharp");

            // Func delegate assigned in different ways

            Func<string, string> executeNamedFunc = new Func<string, string>(Reverse);

            Func<string, string> executeNamedFuncShorter = Reverse;

            Func<string, string> executeAnonymousFunc
                = delegate (string text)
                {
                    return Reverse(text);
                };

            Func<string, string> executeLambdaFunc
                = text => Reverse(text);

            WriteText(executeNamedFunc("Func delegate in CSharp"));
            WriteText(executeNamedFuncShorter("Func delegate in CSharp"));
            WriteText(executeAnonymousFunc("Func delegate in CSharp"));
            WriteText(executeLambdaFunc("Func delegate in CSharp"));

            // Chain Action delegate

            Action executeChainAction = () => WriteText("Call Number One");
            executeChainAction += () => WriteText("Call Number Two");
            executeChainAction += () => WriteText("Call Number Three");

            executeChainAction();

            // Chain Func delegate

            Func<string> executeChainFunc = () => Reverse("Call Number One");
            executeChainFunc += () => Reverse("Call Number Two");
            executeChainFunc += () => Reverse("Call Number Three");

            WriteText(executeChainFunc());

            // Chain Func delegate GetInvocationList method

            foreach (var function in executeChainFunc.GetInvocationList())
            {
                var chainFunc = (Func<string>)function;
                WriteText(chainFunc());
            }
        }
    }
}