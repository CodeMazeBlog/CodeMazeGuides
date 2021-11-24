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

            //Select premium customers who spend more than 250$ with using lambda functions
            var premiumCusts = customers
                .Where(c => c.Spending > 250);

            foreach (var cust in premiumCusts)
            {
                Console.WriteLine(cust.FirstName);
            }

            //define a Func which we will be assigned by custom function which will select premium customers 
            Func<Customer, bool> selectPremiums = PremiumCustomerSelector;

            //Select premium customers via Func delegate
            var premiumCustsCalculatedByFunc = customers
                .Where(selectPremiums);

            //Customers printed on screen is same 
            foreach (var cust in premiumCustsCalculatedByFunc)
            {
                Console.WriteLine(cust.FirstName);
            }
        }

        private static bool PremiumCustomerSelector(Customer customer)
        {
            if (customer.Spending > 250)
            {
                return true;
            }
            return false;
        }
    }
}
