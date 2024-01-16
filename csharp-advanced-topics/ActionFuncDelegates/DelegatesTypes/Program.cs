﻿delegate int Numbers(int n);

namespace DelegatesTypes
{
    public class Program
    {
        public static int number = 15;
        public static int SumNumber(int p)
        {
            number += p;

            return number;
        }
        static void Main(string[] args)
        {
            var number1 = new Numbers(SumNumber);

            number1(10);
            Console.WriteLine("The number is: {0}", number);
        }
    }
}