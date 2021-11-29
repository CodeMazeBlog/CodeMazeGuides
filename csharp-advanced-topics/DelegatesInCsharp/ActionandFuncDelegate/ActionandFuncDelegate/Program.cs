using System;

namespace ActionandFuncDelegate
{
    class Program
    {   
        public static double sum(int a , double b)
        {
            return a + b;
        }
        public static void PrintSum(int a, double b)
        {
            Console.WriteLine(a + b);
        }
        static void Main(string[] args)
        { 
            //Func Delegate
            Func<int,double,double> funcDelegate = (a,b)=> a+b;
            //Action Delegate
            Action<int, double> Actiondelegate = (a,b) => Console.WriteLine(a+b);
            var result = funcDelegate.Invoke(2, 3.5); // Call a Func Delegate
            Console.WriteLine(result);
            Actiondelegate.Invoke(2, 3.5); // Call an Action Delegate
            
        }
    }
}
