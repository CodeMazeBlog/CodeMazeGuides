using System;

namespace Delegates
{
   public class Program
    {
        //define a function that takes two numbers and returns their product 
        public static int CalcProduct(int firstNum, int secondNum)
        {
            return firstNum * secondNum;
        }
        //define a void function that prints the product of two numbers
        public static void PrintProduct(int result)
        {
            Console.WriteLine("The product is {0}", result);
        }
        static void Main(string[] args)
        {
            //define a func delegate that takes two integer inputs and returns an integer output
            Func<int, int, int> product = CalcProduct;
            int result = product(10, 10);
            //create an action delegate
            Action<int> printDelegate = PrintProduct;
            //invoke the delegate 
            printDelegate(result);
            Console.ReadLine();
        }
    }
}
