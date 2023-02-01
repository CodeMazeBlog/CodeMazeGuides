

using System;

namespace FuncAndActionDelegatesInCsharp
{
    class Program
    {
        delegate void CustomDelegate(); 
        private static void MethodA() => Console.WriteLine("Method A Excuted");
        private static void MethodB() => Console.WriteLine("Method B Excuted");

        static void Main(string[] args)
        {
            Delegates();
            TryContinueExecution();

            Console.ReadKey();
        }

        public static void Delegates()
        {
            CustomDelegate unicastDelegate1 = new CustomDelegate(MethodA);
            CustomDelegate unicastDelegate2 = MethodB;

            //multicast delegate that refere to mutible methods
            CustomDelegate multicastDelegate = unicastDelegate1 + unicastDelegate2;

            unicastDelegate1();
            unicastDelegate2.Invoke();
            multicastDelegate();

            CustomDelegate lambdaDelegate = () => { Console.WriteLine("Lambda Delegate Executed"); };
            lambdaDelegate();

            //Action Delegate
            Action actionDelegate1 = new Action(MethodA);
        }

        static void TryContinueExecution()
        {
            var u = string.Empty;
            var result = ContinueExecutionUsingFunc.Operation1(u); 
            if (result.HasErrors)
            { 
                //Save result.LastFailedOperationName to use it later.
            }

            var lastFailedOperationName = nameof(ContinueExecutionUsingFunc.Operation3);
            //Continue From Operation 3
            result = ContinueExecutionUsingFunc.ContinueExcution(lastFailedOperationName, u);

        }
    }
}
