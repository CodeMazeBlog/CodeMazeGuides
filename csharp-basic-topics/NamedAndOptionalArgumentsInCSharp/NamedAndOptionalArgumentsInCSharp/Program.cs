using System;
using System.Runtime.InteropServices;

namespace NamedAndOptionalArgumentsInCSharp
{
    public class Program
    { 
        public static string GetFullName(string firstName, string lastName)
        {
            return $"{ firstName} { lastName}";
        }

        public static int Add(int num1, int num2 = 10, int num3 = 20)
        {
            return num1 + num2 + num3;
        }

        public static int Sum(int num1, int num2, [Optional] int num3)
        {
            return num1 + num2 + num3;
        }

        public static void Main(string[] args)
        {
            var fullName = GetFullName(lastName: "Miller", firstName: "John");
            Console.WriteLine(fullName);

            var addResult = Add(5);
            Console.WriteLine(addResult);

            var sumResult = Sum(10, 20);
            Console.WriteLine(sumResult);
        }
    }
}
