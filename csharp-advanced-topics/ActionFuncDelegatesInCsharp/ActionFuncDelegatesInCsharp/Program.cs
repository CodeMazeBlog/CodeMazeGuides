namespace ActionFuncDelegatesInCsharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Helper.Log("DELEGATE USAGE SAMPLES\n---------------------------------");

            var delegateUsage = new DelegateUsage();
            delegateUsage.SampleLengthFinder("Test message");

            Helper.Log("-----");

            delegateUsage.TestDelegateWithEvent();

            Helper.Log("\nACTION DELEGATES");
            Helper.Log("---------------------------------");

            var actionDelegates = new ActionDelegates();
            actionDelegates.Test();

            Helper.Log("\nFUNC DELEGATES");
            Helper.Log("---------------------------------");

            var funcDelegates = new FuncDelegates();
            funcDelegates.Test();


            Console.ReadLine();
        }
    }
}