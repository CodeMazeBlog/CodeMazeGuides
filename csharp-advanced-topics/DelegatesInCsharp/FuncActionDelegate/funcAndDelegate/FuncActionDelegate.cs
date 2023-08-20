using System;
namespace FuncActionDelegateSample
{
    public class FuncActionDelegate
    {
        public FuncActionDelegate()
        {
        }

        public void PrintFullName(string firstName, string lastName)
        {
            Console.Write(firstName + " "+ lastName);
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}

