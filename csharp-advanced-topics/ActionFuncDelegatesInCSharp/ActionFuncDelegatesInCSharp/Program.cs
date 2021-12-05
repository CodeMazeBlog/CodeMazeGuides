using System;

namespace ActionFuncDelegatesInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Normal Action Delegate
            Action action = TestMethod; 
            action += () => Console.WriteLine("Default"); 
            action();

            //Action Delegate with a generic parameter
            Action<int> actionGeneric = TestMethod;
            actionGeneric += (val) => Console.WriteLine(val);
            actionGeneric(10);


            //Func Delegate without an input parameter
            Func<int> funcDel = FuncMethod; 
            funcDel += () => 100; 
            Console.WriteLine(funcDel()); // returns 100

            //Func Delegate with parameters
            Func<int, int, int> funcDelParams = FuncMethod; 
            Console.WriteLine(funcDelParams(100, 5)); //returns 20
        }


        public static void TestMethod() 
        { 
            Console.WriteLine("Test Method"); 
        }

        public static void TestMethod(int number)
        { 
            Console.WriteLine(number + 20); 
        }

        public static int FuncMethod() 
        { 
            return 50; 
        }

        public static int FuncMethod(int score, int count) 
        { 
            return score / count; 
        }
    }
}
