using DifferentTypesOfCommentsInCSharp;

namespace Tests
{
    [TestClass]
    public class SingleLineCommentsUnitTest
    {
        [TestMethod]
        public void GivenValueLessThan0_WhenCalculatinFactorial_ThenTheResultIsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                SingleLineComments.Factorial(-1);
            });
        }

        [TestMethod]
        public void GivenValue0_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, SingleLineComments.Factorial(0));
        }

        [TestMethod]
        public void GivenValue1_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, SingleLineComments.Factorial(1));
        }

        [TestMethod]
        public void GivenValue2_WhenCalculatinFactorial_ThenTheResultIs2()
        {
            Assert.AreEqual(2, SingleLineComments.Factorial(2));
        }

        [TestMethod]
        public void GivenValue6_WhenCalculatinFactorial_ThenTheResultIs720()
        {
            Assert.AreEqual(720, SingleLineComments.Factorial(6));
        }

        [TestMethod]
        public void GivenValue10_WhenCalculatinFactorial_ThenTheResultIs3628800()
        {
            Assert.AreEqual(3628800, SingleLineComments.Factorial(10));
        }
    }
}