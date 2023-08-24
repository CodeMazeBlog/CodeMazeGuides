using DifferentTypesOfCommentsInCSharp;

namespace Tests
{
    [TestClass]
    public class MixedLineCommentsUnitTest
    {
        [TestMethod]
        public void GivenValueLessThan0_WhenCalculatinFactorial_ThenTheResultIsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                MixedLineComments.Factorial(-1);
            });
        }

        [TestMethod]
        public void GivenValue0_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, MixedLineComments.Factorial(0));
        }

        [TestMethod]
        public void GivenValue1_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, MixedLineComments.Factorial(1));
        }

        [TestMethod]
        public void GivenValue2_WhenCalculatinFactorial_ThenTheResultIs2()
        {
            Assert.AreEqual(2, MixedLineComments.Factorial(2));
        }

        [TestMethod]
        public void GivenValue6_WhenCalculatinFactorial_ThenTheResultIs720()
        {
            Assert.AreEqual(720, MixedLineComments.Factorial(6));
        }

        [TestMethod]
        public void GivenValue10_WhenCalculatinFactorial_ThenTheResultIs3628800()
        {
            Assert.AreEqual(3628800, MixedLineComments.Factorial(10));
        }
    }
}