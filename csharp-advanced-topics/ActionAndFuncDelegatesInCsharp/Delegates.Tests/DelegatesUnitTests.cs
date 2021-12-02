using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Delegates.Tests
{
    [TestClass]
    public class DelegatesUnitTests
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        [TestMethod]
        public void AddFunc_OnPositiveParameters_ReturnsCorrectSum()
        {
            Func<int, int, int> sum = Add;

            var result = sum(3, 6);

            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void AddFunc_OnNegativeParameters_ReturnsCorrectSum()
        {
            Func<int, int, int> sum = Add;

            var result = sum(-6, 1);

            Assert.AreEqual(result, -5);
        }

        [TestMethod]
        public void AddFunc_OnNeutralParameter_ReturnsCorrectSum()
        {
            Func<int, int, int> sum = Add;

            var result = sum(0, 1);

            Assert.AreEqual(result, 1);
        }
    }
}
