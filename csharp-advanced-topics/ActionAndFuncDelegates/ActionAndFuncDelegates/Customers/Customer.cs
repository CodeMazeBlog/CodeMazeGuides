using System;
using System.Collections.Generic;

namespace ActionAndFuncDelegates.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsAssociatedWithCompany { get; set; }
        public double Purchases { get; set; }

        public static void IsRewardableWithoutDelegate(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (customer.YearsAssociatedWithCompany >= 2)
                {
                    Console.WriteLine($"Customer {customer.Name} has to be rewarded.");
                }
            }
        }

        public static void IsRewardable(List<Customer> customers, Func<Customer, bool> isEligible)
        {
            foreach (var customer in customers)
            {
                if (isEligible(customer))
                {
                    Console.WriteLine($"Customer {customer.Name} has to be rewarded.");
                }
            }
        }
    }
}
