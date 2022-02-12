using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class Operations
    {
        public string Name { get; } = "Joe";

        public void SayHi()
        {
            Console.WriteLine($"Hi, {Name}");
        }

        public static void SayHiToFullName(string firtsName, string lastName)
        {
            Console.WriteLine($"Hi, {firtsName} {lastName}");
        }

        public string GetName()
        {
            return Name;
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }


    }
}
