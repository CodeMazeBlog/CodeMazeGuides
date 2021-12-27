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
        public void whenCallingGetSecureRandomNumber_thenWithinRange()
        {
            int upperBound = 100;
            var num = Program.getSecureRandomNumber(upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound ) Assert.Fail("Number Not within Range");
        }

        [TestMethod]
        public void whenCallingGetPseudoRandomNumberWithinRange_thenWithinRange()
        {
            int lowerBound = 2;
            int upperBound = 200;
            var num = Program.getPseudoRandomNumberWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }

        [TestMethod]
        public void whenCallingGetSecureNumberWithinRange_thenWithinRange()
        {
            int lowerBound = 3;
            int upperBound = 300;
            var num = Program.getSecureNumberWithinRange(lowerBound, upperBound);
            Assert.IsNotNull(num);
            if (num >= upperBound || num < lowerBound) Assert.Fail("Number Not within Range");
        }
        
        [TestMethod]
        public void whenCallingGetPseudoRandomNumberThreadSafe_thenNotNull()
        {
            var num = Program.getPseudoRandomNumberThreadSafe();
            Assert.IsNotNull(num);
        }

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
            var num = Program.getPseudoDoubleWithinRange(lowerBound,upperBound);
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