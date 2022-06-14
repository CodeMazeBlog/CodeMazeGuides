using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionVsFuncDelegatesTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void whenIntegerIsSent_DeletagesReturnIncreasedCount()
        {
            var increaseCount = delegate (int count)
            {
                count++;
                Assert.AreEqual(6, count);
            };
            increaseCount.Invoke(5);
        }
        [TestMethod]
        public void whenTwoDifferentIntegersIsSent_DeletagesReturnTheMaxOne()
        {
            Func<byte> getMaxNumber = delegate ()
            {
                byte val1 = 100, val2 = 50;
                return Math.Max(val1, val2);
            };

            Assert.AreEqual(100, getMaxNumber());
        }
        [TestMethod]
        public void whenTwoDifferentIntegersIsSent_DeletagesReturnTheMaxOne2()
        {
            Func<int, int, int> sum = (x, y) => x + y;

            Assert.AreEqual(15, sum.Invoke(10, 5));
        }
    }
}