using System;

namespace ActionAndFuncDelegates
{
    internal class FuncWithParametersAndReturnValue
    {
        static void Main(string[] args)
        {
            // Func Delegate with one parameters and Return value

            Func<int, int> Square = a => a * a;

            Console.WriteLine($"Area of Square is: {Square(4)}"); // Output => Area of Square is: 16

            // Func Delegate with two parameters and Return value
            Func<int, int, int> Rectangle = (a, b) => a * b;
            Console.WriteLine($"Area of Rectangle is: {Rectangle(4, 3)}"); // Output => Area of Rectangle is: 12

            Console.ReadLine();
        }
    }
}
