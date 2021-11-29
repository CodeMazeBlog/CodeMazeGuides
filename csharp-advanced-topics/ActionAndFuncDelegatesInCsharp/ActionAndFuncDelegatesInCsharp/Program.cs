using System;

namespace ActionAndFuncDelegatesInCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Action printName = PrintName;
            printName();

            Action<string, int> printFullName = FullNameAndAge;
            printFullName("Umoh Tobby", 23);

            // Normal syntax
            Func<int, string, string> func1 = FullDetails;

            var printDetails = func1(23, "Umoh");
            Console.WriteLine(printDetails);

            // Anonymous type
            Func<int, string, string> func2 = delegate (int age, string name)
            {
                return $"My name is {name}, i am {age} years old";
            };

            var printAgeAndName = func2(23, "Tobby");
            Console.WriteLine(printAgeAndName);

            // Lambda Expression
            Func<int, string, string> func3 = (age, name) => $"My name is {name} and i am {age} years old";

            var printAgeAndName2 = func3(23, "Tobby");
            Console.WriteLine(printAgeAndName2);
        }

        public static void PrintName() => Console.WriteLine($"My name is Tobby");

        public static void FullNameAndAge(string fullName, int age) => Console.WriteLine($"My full name is {fullName}, and i am {age} years old");

        public static void UsingActionDelegates()
        {
            Action printName = PrintName;
            printName();
        }
        public static string FullDetails(int age, string name)
        {
            return $"My name is {name} and i am {age} years old";
        }

    }

}