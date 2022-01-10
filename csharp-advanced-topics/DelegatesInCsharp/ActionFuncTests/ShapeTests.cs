using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionFunc.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        [TestMethod()]
        public void PrintTest()
        {
            try
            {
                var shape = new Shape();

                Action<int> action = shape.Print;
                action(9);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void ComputeTest()
        {
            int firstValue = 3;
            int secondValue = 9;
            int expected = 27;
            var shape = new Shape();
            Func<int, int, int> func = shape.Compute;
            // act
            var result = func(firstValue, secondValue);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}