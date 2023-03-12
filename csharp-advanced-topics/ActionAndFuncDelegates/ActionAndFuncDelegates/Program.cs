namespace delegates;

class Program
{
    static void Main(string[] args)
    {
        #region Action Delegates

        Action actionDelegate = SayHelloToTheWorld;
        actionDelegate.Invoke();

        Action<string, string> actionDelegateWithParams = ShowYourParameters;
        actionDelegateWithParams("Beautiful", "World");

        Action<int> actionDelegateWithAnonMethod = delegate (int param)
        {
            Console.WriteLine("Hello there, you send us " + param + " stars");
        };
        actionDelegateWithAnonMethod(3);

        Action actionDelegateWithLambda = () =>
        {
            Console.Write("I am inside the lambda statement");
        };
        actionDelegateWithLambda();

        #endregion

        #region Func Delegates

        Func<string, int> funcDelegateWithParams = GetCharacterCount;
        var stringLength = GetCharacterCount("Count Me");
        var myLength = funcDelegateWithParams.Invoke("Count Me Using Invoke");

        Func<string> funcDelegateWithoutParams = SayHelloWorld;
        var helloString = SayHelloWorld();

        Func<int, string> funcDelegateWithAnonMethod = delegate (int param)
        {
            return "Hello there, you send us " + param + " stars";
        };
        funcDelegateWithAnonMethod(3);

        Func<string> funcDelegateWithLambda = () =>
        {
            return "I am inside the lambda statement";
        };
        funcDelegateWithLambda();
        #endregion

    }
    public static string SayHelloWorld()
    {
        return "Hello, World!";
    }
    public static void SayHelloToTheWorld()
    {
        Console.WriteLine("Hello, World!");
    }

    public static void ShowYourParameters(string firstParameter, string secondParamter)
    {
        Console.WriteLine("First Parameter: " + firstParameter + ", Second Paramter: " + secondParamter);
    }
    public static int GetCharacterCount(string theBigWord)
    {
        return theBigWord.Length;
    }
}
