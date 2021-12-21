using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateRandomNumbers
{
    [TestClass]
    public class GenerateRandomNumbersTests
    {
        [TestMethod]
        public void whenCallingGetPseudoRandomNumber_thenNotNull()
        {
            var num = Program.getPseudoRandomNumber();
            Assert.IsNotNull(num);
        }
        [TestMethod]
        public void whenCallingGetPseudoRandomNumberWithSeed_thenNotNull()
        {
            int seed = 2;
            var num = Program.getPseudoRandomNumberWithSeed(seed);
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetSecureRandomNumber_thenNotNull()
        {
            int upperBound = 100;
            var num = Program.getSecureRandomNumber(upperBound);
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetPseudoRandomNumberWithinRange_thenNotNull()
        {
            int lowerBound = 2;
            int upperBound = 200;
            var num = Program.getPseudoRandomNumberWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetSecureNumberWithinRange_thenNotNull()
        {
            int lowerBound = 3;
            int upperBound = 300;
            var num = Program.getSecureNumberWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetPseudoDouble_thenNotNull()
        {
            var num = Program.getPseudoDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetSecureDouble_thenNotNull()
        {
            var num = Program.getSecureDouble();
            Assert.IsNotNull(num);
        }
    }
}