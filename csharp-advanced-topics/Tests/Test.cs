using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using CsharpDelegatesActionFunc;
using System;

namespace Tests
{
    delegate string getInterestRate(double time, double rate);

    [TestClass]
    public class Test
    {

        [TestMethod]
        public void WhenRateAndTimeIsSentForSingleMethod_DelegateExecutesTheReferencedMethod()
        {
            getInterestRate delegateTotalInterest = new getInterestRate(InterestService.GetTotalInterestByHours);

            string result = delegateTotalInterest.Invoke(8, 10);

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8", result);
        }

        [TestMethod]
        public void WhenRateAndTimeIsSentForMultipleMethods_DelegateExecutesTheReferencedMethods()
        {
            getInterestRate delegateTotalInterest = new getInterestRate(InterestService.GetTotalInterestByHours); 
            
            delegateTotalInterest += InterestService.GetTotalInterestByMinutes;
            StringBuilder sb = new StringBuilder();
            foreach (var del in delegateTotalInterest.GetInvocationList())
            {
                string result = (string)del.DynamicInvoke(8, 10);
                sb.Append(result + " - ");
            }

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8 - Total Interest of $10 rate in 0.133 hours is 0.013 - ", sb.ToString());
        }

        [TestMethod]
        public void WhenActionDelegateSingleMethod_DelegateInvocationListNotEmpty()
        {
            Action<double, double> executeGetTotalInterest = InterestService.PrintTotalInterestByHours;

            var invocationList = executeGetTotalInterest.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void WhenActionDelegateMultipleMethods_DelegateInvocationListNotEmpty()
        {
            Action<double, double> executeGetTotalInterest = InterestService.PrintTotalInterestByHours;

            executeGetTotalInterest += InterestService.PrintTotalInterestByMinutes;
            var invocationList = executeGetTotalInterest.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 2);
        }

        [TestMethod]
        public void WhenFuncDelegateSingleMethod_DelegateExecutesTheReferencedMethod()
        {
            Func<double, double, string> executeGetTotalInterest = InterestService.GetTotalInterestByHours; 

            var result = executeGetTotalInterest(8, 10); 

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8", result);
        }

        [TestMethod]
        public void WhenFuncDelegateMultipleMethods_DelegateExecutesTheReferencedMethods()
        {
            Func<double, double, string> executeGetTotalInterest = InterestService.GetTotalInterestByHours;

            executeGetTotalInterest += InterestService.GetTotalInterestByMinutes;
            var sb = new StringBuilder();
            foreach (var del in executeGetTotalInterest.GetInvocationList())
            {
                var result = (string)del.DynamicInvoke(8, 10);
                sb.Append(result + " - ");
            }

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8 - Total Interest of $10 rate in 0.133 hours is 0.013 - ", sb.ToString());
        }
    }

}
