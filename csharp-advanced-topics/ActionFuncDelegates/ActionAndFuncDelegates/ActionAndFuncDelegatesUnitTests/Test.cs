
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionAndFuncDelegatesUnitTests
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsAssociatedWithCompany { get; set; }
        public double Purchases { get; set; }
    }

    public delegate string PrintMessageDelegate(string message);
    public delegate bool IsEligible(bool condition);

    [TestClass]
    public class Test
    {
        public static string Print(string message)
        {
            return $"Hello {message}";
        }

        public static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public static bool IsEligibleForReward(Customer customer)
        {
            return customer.YearsAssociatedWithCompany >= 2;
        }

        public static bool IsEligibleForRewardForPurchases(Customer customer)
        {
            return customer.Purchases >= 5000;
        }

        [TestMethod]
        public void WhenStringMessage_ThenItShouldAppendHelloToStringMessage()
        {
            var printMessage = new PrintMessageDelegate(Print);
            Assert.AreEqual("Hello World!!", printMessage("World!!"));
        }

        [TestMethod]
        public void WhenAddTwoNumbers_ThenItShouldReturnTheSum()
        {
            Func<int, int, int> add = Add;
            var result = add(10, 20);
            Assert.AreEqual(30,result);
        }

        [TestMethod]
        public void WhenAddTwoNegativeNumbers_ThenItShouldReturnTheSum()
        {
            Func<int, int, int> add = Add;
            var result = add(-10, -20);
            Assert.AreEqual(-30, result);
        }

        [TestMethod]
        public void WhenYearsAssociatedWithCompanyIs3_ReturnTrue()
        {
            var customer = new Customer
            {
                Id = 999,
                Name = "Randy",
                YearsAssociatedWithCompany = 3,
                Purchases = 10000
            };
            Func<Customer, bool> iseligible = IsEligibleForReward;
            var result = iseligible(customer);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void WhenYearsAssociatedWithCompanyIs1_ReturnFalse()
        {
            var customer = new Customer
            {
                Id = 1001,
                Name = "Roger",
                YearsAssociatedWithCompany = 1,
                Purchases = 6000
            };
            Func<Customer, bool> iseligible = IsEligibleForReward;
            var result = iseligible(customer);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void WhenPurchasesMoreThan5000_ReturnTrue()
        {
            var customer = new Customer
            {
                Id = 1002,
                Name = "Tom",
                YearsAssociatedWithCompany = 1,
                Purchases = 8000
            };
            Func<Customer, bool> iseligible = IsEligibleForRewardForPurchases;
            var result = iseligible(customer);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void WhenPurchasesLessThan5000_ReturnFalse()
        {
            var customer = new Customer
            {
                Id = 1003,
                Name = "Sam",
                YearsAssociatedWithCompany = 5,
                Purchases = 4000
            };
            Func<Customer, bool> iseligible = IsEligibleForRewardForPurchases;
            var result = iseligible(customer);
            Assert.AreEqual(false, result);
        }
    }
}