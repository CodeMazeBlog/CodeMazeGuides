using ActionAndFuncDelegates.Customers;
using System;

namespace ActionAndFuncDelegates
{
    public delegate string PrintMessageDelegate(string message);
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintMessageDelegate printMessage = new PrintMessageDelegate(Print);
            printMessage("From C# Delegates");

            Action<int, int> add = (num1, num2) => Console.WriteLine("Sum of num1 and num2 is {0}.", num1 + num2);
            add(10, 20);

            Func<int, int, string> multiplyAndDisplay = (num1, num2) => $"Multiplication of num1 and num2 is {num1 * num2}.";
            Console.WriteLine(multiplyAndDisplay(10, 20));

            var customers = CustomerData.GetCustomers();

            //logic without delegate
            Customer.IsRewardableWithoutDelegate(customers);

            Console.WriteLine("************************");

            //first logic with Func
            Customer.IsRewardable(customers, cust => cust.YearsAssociatedWithCompany >= 2);

            Console.WriteLine("************************");

            //second logic with Func
            Customer.IsRewardable(customers, cust => cust.Purchases >= 10000);

            Console.ReadLine();
        }

        public static string Print(string message)
        {
            return $"Hello {message}";
        }
    }
}