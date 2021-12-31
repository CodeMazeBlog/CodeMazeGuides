using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateRandomNumbers
{
    [TestClass]
    public class GenerateRandomNumbersTests
    {
        [TestMethod]
        public void whenCallingGetPseudoDouble_thenNotNull()
        {
            var num = Program.getPseudoDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetPseudoDoubleWithinRange_thenWithinRange()
        {
            double lowerBound = 4;
            double upperBound = 400;
            var num = Program.getPseudoDoubleWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }

        [TestMethod]
        public void whenCallingGetSecureDouble_thenNotNull()
        {
            var num = Program.getSecureDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetSecureDoubleWithinRange_thenWithinRange()
        {
            double lowerBound = 5;
            double upperBound = 500;
            var num = Program.getSecureDoubleWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }
    }
}