using System;
using System.Text;

namespace AddParametersToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "John Doe";

            var age = 26;
            
            Console.WriteLine(string.Format("Hi, my name is {0}.", name));

            Console.WriteLine(string.Format("Hi, my name is {0}. I am {1} years old.", name, age));

            string greeting = "Hi, my name is username. I am age years old.";

            Console.WriteLine(greeting.Replace("username", name).Replace("age", age.ToString()));

            Console.WriteLine($"Hi, my name is {name}. I am {age} year{(age == 1 ? "" : "s")} old.");

            var builder = new StringBuilder();

            builder.AppendFormat("Hi, my name is {0}. I am {1} years old.", name, age);

            Console.WriteLine(builder);
        }
    }
}
