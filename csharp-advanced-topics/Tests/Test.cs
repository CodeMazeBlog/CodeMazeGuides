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
            getInterestRate delegateTotalInterest = new getInterestRate(InterestService.getTotalInterestByHours);

            string result = delegateTotalInterest.Invoke(8, 10);

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8", result);
        }

        [TestMethod]
        public void WhenRateAndTimeIsSentForMultipleMethods_DelegateExecutesTheReferencedMethods()
        {
            getInterestRate delegateTotalInterest = new getInterestRate(InterestService.getTotalInterestByHours); 

            delegateTotalInterest += InterestService.getTotalInterestByMinutes;
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
            Action<double, double> executeGetTotalInterest = InterestService.printTotalInterestByHours;

            var invocationList = executeGetTotalInterest.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void WhenActionDelegateMultipleMethods_DelegateInvocationListNotEmpty()
        {
            Action<double, double> executeGetTotalInterest = InterestService.printTotalInterestByHours;

            executeGetTotalInterest += InterestService.printTotalInterestByMinutes;
            var invocationList = executeGetTotalInterest.GetInvocationList();

            Assert.AreEqual(invocationList.Length, 2);
        }

        [TestMethod]
        public void WhenFuncDelegateSingleMethod_DelegateExecutesTheReferencedMethod()
        {
            Func<double, double, string> executeGetTotalInterest = InterestService.getTotalInterestByHours; 

            var result = executeGetTotalInterest(8, 10); 

            Assert.AreEqual("Total Interest of $10 rate in 8 hours is 0.8", result);
        }

        [TestMethod]
        public void WhenFuncDelegateMultipleMethods_DelegateExecutesTheReferencedMethods()
        {
            Func<double, double, string> executeGetTotalInterest = InterestService.getTotalInterestByHours;

            executeGetTotalInterest += InterestService.getTotalInterestByMinutes;
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
