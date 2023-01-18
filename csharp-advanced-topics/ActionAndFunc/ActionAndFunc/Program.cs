using System;

namespace ActionAndFunc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<string> toppingAction = PrintToping;
            toppingAction += x => Console.WriteLine($"Adding double {x} to your pizza.");

            toppingAction("Tomato sauce");
            toppingAction("Pepperoni");
            toppingAction("Buffalo mozzarella");

            Console.WriteLine();

            Func<string, string> toppingFunc = AddToping;
            toppingFunc += x => $"Adding double {x} to your pizza.";

            var toppings = new List<string>
            {
                toppingFunc("Tomato sauce"),
                toppingFunc("Pepperoni"),
                toppingFunc("Buffalo mozzarella")
            };

            Console.WriteLine(string.Join(Environment.NewLine, toppings));
        }

        public static void PrintToping(string topping) => Console.WriteLine($"{topping} was added to your pizza.");

        public static string AddToping(string topping) => $"{topping} was added to your pizza.";
    }
}