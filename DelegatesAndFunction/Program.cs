using System;

public class Program
{
    public static void Main()
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Action delegate");
            Console.WriteLine("2. Func delegate");
            Console.WriteLine("3. Exit program");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Action<int, int> actionDelegate = (x, y) =>
                    {
                        int sum = x + y;
                        Console.WriteLine("The sum of " + x + " and " + y + " is " + sum);
                    };

                    Console.WriteLine("Enter two numbers:");
                    int num1, num2;
                    if (int.TryParse(Console.ReadLine(), out num1) && int.TryParse(Console.ReadLine(), out num2))
                    {
                        actionDelegate(num1, num2);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter valid integer values.");
                    }

                    break;
                case "2":
                    Func<int, int, int> funcDelegate = (x, y) =>
                    {
                        return x + y;
                    };

                    Console.WriteLine("Enter two numbers:");
                    int num3, num4;
                    if (int.TryParse(Console.ReadLine(), out num3) && int.TryParse(Console.ReadLine(), out num4))
                    {
                        int sum = funcDelegate(num3, num4);
                        Console.WriteLine("The sum of " + num3 + " and " + num4 + " is " + sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter valid integer values.");
                    }

                    break;
                case "3":
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

