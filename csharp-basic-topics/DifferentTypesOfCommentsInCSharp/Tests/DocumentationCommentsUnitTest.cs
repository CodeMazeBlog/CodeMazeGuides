using DifferentTypesOfCommentsInCSharp;

namespace Tests
{
    [TestClass]
    public class DocumentationCommentsUnitTest
    {
        [TestMethod]
        public void GivenValueLessThan0_WhenCalculatinFactorial_ThenTheResultIsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                DocumentationComments.Factorial(-1);
            });
        }

        [TestMethod]
        public void GivenValue0_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, DocumentationComments.Factorial(0));
        }

        [TestMethod]
        public void GivenValue1_WhenCalculatinFactorial_ThenTheResultIs1()
        {
            Assert.AreEqual(1, DocumentationComments.Factorial(1));
        }

        [TestMethod]
        public void GivenValue2_WhenCalculatinFactorial_ThenTheResultIs2()
        {
            Assert.AreEqual(2, DocumentationComments.Factorial(2));
        }

        [TestMethod]
        public void GivenValue6_WhenCalculatinFactorial_ThenTheResultIs720()
        {
            Assert.AreEqual(720, DocumentationComments.Factorial(6));
        }

        [TestMethod]
        public void GivenValue10_WhenCalculatinFactorial_ThenTheResultIs3628800()
        {
            Assert.AreEqual(3628800, DocumentationComments.Factorial(10));
        }

        [TestMethod]
        public void GivenPriceWithoutTaxOf100_WhenTaxPercIs20_ThenTaxis20()
        {
            Assert.AreEqual(20, DocumentationComments.CalculateTax(100, 20, false));
        }

        [TestMethod]
        public void GivenPriceWithTaxOf120_WhenTaxPercIs20_ThenTaxis20()
        {
            Assert.AreEqual(20, DocumentationComments.CalculateTax(120, 20, true));
        }

    }
}