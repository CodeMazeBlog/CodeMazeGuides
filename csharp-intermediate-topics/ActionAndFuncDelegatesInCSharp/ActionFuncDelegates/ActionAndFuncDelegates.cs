using System;

namespace ActionFuncDelegates
{
    public class ActionAndFuncDelegates
    {
        public static void Main()
        {
            // Action delegate with named method
            Action<String> CustomerInfo = InfoMethod;

            CustomerInfo("Welcome to our restaurant!");

            //Func delegate with named method to calculate order total
            Func<decimal, decimal, decimal, decimal> orderTotal = CalculateOrder;

            Console.WriteLine($"Your total is: {orderTotal(4.76M, 3.12M, 5.77M):C2}");

            //Func delegate with lambda expression to calculate order total
            Func<decimal, decimal, decimal, decimal> LambdaCalculateOrder = (mealOne, mealTwo, mealThree) =>
            {
                decimal calculatedTotal = mealOne + mealTwo + mealThree;

                return calculatedTotal;
            };

            Console.WriteLine();
            Console.WriteLine($"Your yesterday's total was: {LambdaCalculateOrder(13.5M, 6.3M, 21.7M):C2}");

            // Action delegate with lambda expression
            Action<String> LambdaCustomerInfo = (info) => Console.WriteLine(info);

            LambdaCustomerInfo("Thank you for your order!");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void InfoMethod(string info)
        {
            Console.WriteLine(info);
            Console.WriteLine();
        }

        public static decimal CalculateOrder(decimal mealOne, decimal mealTwo, decimal mealThree)
        {
            decimal total = mealOne + mealTwo + mealThree;

            return total;
        }
    }
}

