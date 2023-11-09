using DifferentTypesOfCommentsInCSharp;

namespace Tests
{
    [TestClass]
    public class MultiLineCommentsUnitTest
    {
        [TestMethod]
        public void GivenValueLessThan0_WhenCalculatinFactorial_ThenTheResultIsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MultiLineComments.Factorial(-1);
            });
        }

        [TestMethod]
        public void GivenValue0_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, MultiLineComments.Factorial(0));
        }

        [TestMethod]
        public void GivenValue1_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, MultiLineComments.Factorial(1));
        }

        [TestMethod]
        public void GivenValue2_WhenCalculatinFactorial_ThenTheResultIs2()
        {
            Assert.AreEqual(2, MultiLineComments.Factorial(2));
        }

        [TestMethod]
        public void GivenValue6_WhenCalculatinFactorial_ThenTheResultIs720()
        {
            Assert.AreEqual(720, MultiLineComments.Factorial(6));
        }

        [TestMethod]
        public void GivenValue10_WhenCalculatinFactorial_ThenTheResultIs3628800()
        {
            Assert.AreEqual(3628800, MultiLineComments.Factorial(10));
        }
    }
}