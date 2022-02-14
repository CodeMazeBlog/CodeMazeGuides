using System;

namespace ActionAndFuncDelegates.Actions
{
    class LambdaExpressionsAction
    {
        public static void Test()
        {
            Action sayWithLambda = () =>
            {
                Console.WriteLine("Hello from Lambda Expression");
            };

            sayWithLambda();
        }
    }
}
