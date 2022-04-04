using GenerateRandom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GenerateRandom.Program;

namespace GenerateRandomTests
{
    [TestClass]
    public class GenerateRandomTest
    {
        public void WhenCallingGetPseudoRandomNumber_thenNotNull()
        {
            var num = GetPseudoRandomNumber();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingGetPseudoDouble_thenNotNull()
        {
            var num = GetPseudoDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingGetPseudoRandomNumberThreadSafe_thenNotNull()
        {
            var num = GetPseudoRandomNumberThreadSafe();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingGePseudoRandomString_thenNotNull()
        {
            int count = 100;
            var num = GetPseudoRandomString(count);
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void WhenCallingRandomCustomNext_thenNotNull()
        {
            var rc = new RandomCustom();
            var num = rc.Next();
            Assert.IsNotNull(num);
        }
    }
}