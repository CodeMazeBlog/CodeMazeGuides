using System;
/// <summary>
/// Alireza Gadyari
/// Aligady@gmail.com
/// </summary>
namespace ActionAndFuncDelegatesInCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Action delegate in c#
            ActionDelegate();
            ActionDelegateByAnonymous();
            ActionDelegateByLambdaExpression();
            #endregion

            #region Func delegate in c#
            Display(FuncDelegate());
            Display(FuncDelegateByAnonymous());
            Display(FuncDelegateByLambdaExpression());
            #endregion
        }

        #region Action Methods
        public static int ActionDelegate()
        {
            Action<string> displayAction = Display;
            displayAction("Hello world!");
            return displayAction.GetInvocationList().Length;
        }
        public static int ActionDelegateByAnonymous()
        {
            Action<string> displayActionAnonymous = delegate (string message)
            {
                Console.WriteLine(message);
            };
            displayActionAnonymous("Hello world!");
            return displayActionAnonymous.GetInvocationList().Length;
        }
        public static int ActionDelegateByLambdaExpression()
        {
            Action<string> displayActionLambda = message => Console.WriteLine(message);
            displayActionLambda("Hello world!");
            return displayActionLambda.GetInvocationList().Length;
        }

        #endregion

        #region Func Methods
        public static int FuncDelegate()
        {
            Func<int, int, int> multiplyFunc = Multiply;
            int result = multiplyFunc(8, 10);
            return result;
        }

        public static int FuncDelegateByAnonymous()
        {
            Func<int, int, int> multiplyFuncAnonymous = delegate (int x, int y)
            {
                return x * y;
            };
            int resultAnonymous = multiplyFuncAnonymous(5, 10);
            return resultAnonymous;
        }

        public static int FuncDelegateByLambdaExpression()
        {
            Func<int, int, int> multiplyFuncLambda = (x, y) => x * y;
            int resultLambda = multiplyFuncLambda(4, 10);
            return resultLambda;
        }
        #endregion

        #region Other Methods
        static void Display(string message)
        {
            Console.WriteLine(message);
        }

        static void Display(int value)
        {
            Console.WriteLine(value.ToString());
        }

        static int Multiply(int x, int y)
        {
            return x * y;
        }
        #endregion

    }
}
