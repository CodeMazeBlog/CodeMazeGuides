using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class Demo
    {
        // Create a function that an Action delegate will reference.
        public static void PrintInfo(string first, string last, int age)
        {
            Console.WriteLine($"FirstName: {first}\nLastName: {last}\nAge: {age}");
        }

        public static void ActionDemo()
        {
            Console.WriteLine("*** An Action delegate demo ***");

            // Action delegate in action...
            Action<string, string, int> info = PrintInfo;
            info("don", "go", 25);
            Console.WriteLine("--- end of demo ---");
        }


        // Create a function that a Func delegate will reference.
        public static int GetAge(DateOnly bd)
        {
            int i = DateTime.Today.Year - bd.Year;
            return i;
        }
        public static void FuncDemo()
        {
            Console.WriteLine("*** A Func delegate demo ***");
            // Func delegate in action...
            Func<DateOnly, int> target = GetAge;
            DateOnly birthDay = new DateOnly(1998, 12, 25);
            int age = target(birthDay);

            // Print the Age according to birthday
            Console.WriteLine($"If your birthday is: {birthDay}\nYour age is: {age}");
            Console.WriteLine("--- end of demo ---");
        }
    }
}
