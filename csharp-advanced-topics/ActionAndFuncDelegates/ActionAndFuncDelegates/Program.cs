using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }


        static void Main(string[] args)
        {

            //Func Delegate using a Function
            Func<int, int, int> sumFunc = Sum;
            int result = sumFunc(2, 3);
            Console.WriteLine(result);

            //Action Delegate using a Function
            Action<int, int> addAction = Add;
            addAction(5, 8);

            //Func Delegate using a delegate keyword
            Func<int, int> delegateFunc = delegate (int num)
            {
                return num * num;
            };
            int sqrNum = delegateFunc(3);
            Console.WriteLine(sqrNum);

            //Action Delegate using a delegate keyword
            Action<int> delegateAction = delegate (int num)
            {
                Console.WriteLine(num * num);
            };
            delegateAction(5);

            //Func Delegate using a lambda expression
            Func<int, int> lambdaFunc = (int num) => num * num;
            int sqrLambda = lambdaFunc(4);
            Console.WriteLine(sqrLambda);

            //Action Delegate using a lambda expression
            Action<int> lambdaAction = (int num) => Console.WriteLine(num * num);
            lambdaAction(6);
        }
    }
}
