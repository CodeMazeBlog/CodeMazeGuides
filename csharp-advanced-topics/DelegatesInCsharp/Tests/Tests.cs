using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenSimpleInterestIsCalculated_ThenDisplayResult()
        {
            //Arrange
            double principalAmount = 1000;
            float rate = 5.5f;
            int time = 3;
            double expected = 165;

            //Act
            Func<double, float, int, double> funcDelegate = DelegatesInCsharp.Program.CalculateSimpleInterest;
            double actual = funcDelegate.Invoke(principalAmount, rate, time);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
