using System;

namespace ActionAndFuncDelegate
{
    public class Training
    {
        // We're defining a simple add method that takes in two integers as argument
        // adds them up and prints out the result via the console
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }

        public string DisplayDate(DateTime time)
        {
            return $"Time is {time.ToString("MM/dd/yyyy")}";
        }
    }
}
