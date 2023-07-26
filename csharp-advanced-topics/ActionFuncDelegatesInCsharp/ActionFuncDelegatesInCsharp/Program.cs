using ActionFuncDelegatesInCsharp.Logger;

namespace ActionFuncDelegatesInCsharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new DelegateLogger();

            TestDelegates(logger);
            TestActionDelegates(logger);
            TestFuncDelegates(logger);

            Console.ReadLine();
        }

        private static void TestDelegates(DelegateLogger logger)
        {
            logger.Log("DELEGATE USAGE SAMPLES\n---------------------------------");

            var delegateUsage = new DelegateUsage(logger);
            delegateUsage.DelegateAsCallbackParameterUsage("Test message");

            logger.Log("-----");
            delegateUsage.DelegateWithEventUsage(3);
        }

        private static void TestActionDelegates(DelegateLogger logger)
        {
            logger.Log("\nACTION DELEGATES\n---------------------------------");

            var actionDelegates = new ActionDelegates(logger);
            actionDelegates.DelegateWithLambdaExpressionUsage(3,7,"*");
            actionDelegates.DelegateWithLambdaExpressionUsage(5,13,"+");

            logger.Log("-----");
            actionDelegates.DelegateWithReferenceMethodUsage("Test message");
        }

        private static void TestFuncDelegates(DelegateLogger logger)
        {
            logger.Log("\nFUNC DELEGATES\n---------------------------------");

            var funcDelegates = new FuncDelegates(logger);
            funcDelegates.FuncDelegateUsage(30000, 0.20);
        }
    }
}