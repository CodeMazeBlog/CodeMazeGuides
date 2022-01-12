using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateRandomNumbers
{
    [TestClass]
    public class GenerateRandomNumbersTests
    {
        [TestMethod]
        public void WhenCallingGetPseudoDouble_ThenNotNull()
        {
            var num = Program.GetPseudoDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingGetPseudoDoubleWithinRange_ThenWithinRange()
        {
            double lowerBound = 4;
            double upperBound = 400;
            var num = Program.GetPseudoDoubleWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }

        [TestMethod]
        public void WhenCallingGetSecureDouble_ThenNotNull()
        {
            var num = Program.GetSecureDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingGetSecureDoubleWithinRange_ThenWithinRange()
        {
            double lowerBound = 5;
            double upperBound = 500;
            var num = Program.GetSecureDoubleWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }
    }
}