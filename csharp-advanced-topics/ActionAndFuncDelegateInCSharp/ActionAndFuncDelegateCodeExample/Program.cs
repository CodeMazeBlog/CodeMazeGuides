using System;

namespace ActionAndFuncDelegateCodeExample
{
    class Program
    {

        public static void Main(string[] args)
        {
            Func<int, int> funcDelOne = MethodA;
            Func<string> funcDelTwo = MethodB;
            Action<string, int, int> actionDel = MethodC;

            funcDelOne(15);
            funcDelTwo();
            actionDel("Web 3.0", 2, 4);

            //using Lamda expressions
            Func<string, int> lambdaFunc = (string para) => para.Length;
            Action<string> lambdaAction = (string param) => Console.WriteLine(param.Length);

            lambdaFunc("chocolate");
            lambdaAction("melon");

        }

        static int MethodA(int num)
        {
            return num * num;
        }

        static string MethodB()
        {
            return "Code-Maze";
        }

        static void MethodC(string word, int numOne, int numTwo)
        {
            var isEqual = word.Length == (numOne + numTwo);
            Console.WriteLine(isEqual.ToString());
        }
    }
}

