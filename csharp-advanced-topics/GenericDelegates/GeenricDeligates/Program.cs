using System;

namespace GenericDeligates
{
    // Define Delegate for the void return type
    public delegate void DelegateVoid(int x, int y);
  //public static   void SumReturVoid(int x , int y)
 

    // Define Delegate for the Int return type
    public delegate int DelegateInt(int x, int y);
  //public static   int SumReturInt(int x , int y)
   
    class Program
    {
        // Calculate Sum of Two integers and prints the sum
        public static void SumReturVoid(int x, int y)
        {
            int sum = x + y;
            Console.WriteLine("void return type : " + sum);
        }
        // Calculate Sum of Two integers and returns the sum
        public static int SumReturInt(int x, int y)
        {
            int sum = x + y;
            return sum;
        }
        static void Main(string[] args)
        {           
            Action<int,int> objVoid = SumReturVoid;
            Func<int,int,int> objInt  = SumReturInt;

            objVoid.Invoke(10, 20);

            int result = objInt.Invoke(10,20);
            Console.WriteLine("Int  return type : " + result);

            Console.ReadLine();

        }
    }
}
