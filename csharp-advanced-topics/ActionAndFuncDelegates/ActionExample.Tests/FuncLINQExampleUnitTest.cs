using FuncLINQExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Tests
{

    [TestClass]
    public class FuncLINQExampleUnitTest
    {
        [TestMethod]
        public void givenFuncDelegate_whenSendingCustomers_thenReturnPremiumCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Michael" , Spending = 105},
                new Customer { FirstName = "Linda" , Spending = 500},
                new Customer { FirstName = "Elizabeth" , Spending = 300},
                new Customer { FirstName = "William",  Spending = 200},
            };

            //define a Func which we will be assigned by custom function which will select premium customers 
            Func<Customer, bool> selectPremiums = Selector.PremiumCustomerSelector;

            //Select premium customers via Func delegate
            var premiumCustsCalculatedByFunc = customers
                .Where(selectPremiums).ToList();

            var premiumCustomers = new List<Customer>() 
            {
                new Customer { FirstName = "Linda" , Spending = 500},
                new Customer { FirstName = "Elizabeth" , Spending = 300},
            };

            Assert.AreEqual(premiumCustomers.Count, premiumCustsCalculatedByFunc.Count); 

        }
    }
}
