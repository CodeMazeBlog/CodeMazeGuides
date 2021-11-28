using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncLINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Michael" , Spending = 105},
                new Customer { FirstName = "Linda" , Spending = 500},
                new Customer { FirstName = "Elizabeth" , Spending = 300},
                new Customer { FirstName = "William",  Spending = 200},
            };

            var premiumCusts = customers.Where(c => c.Spending > 250);

            foreach (var cust in premiumCusts)
            {
                Console.WriteLine(cust.FirstName);
            }

            Func<Customer, bool> selectPremiums = Selector.PremiumCustomerSelector;

            var premiumCustsCalculatedByFunc = customers
                .Where(selectPremiums);

            foreach (var cust in premiumCustsCalculatedByFunc)
            {
                Console.WriteLine(cust.FirstName);
            }
        }        
    }
}
