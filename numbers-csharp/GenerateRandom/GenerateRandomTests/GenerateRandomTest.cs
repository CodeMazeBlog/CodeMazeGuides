using GenerateRandom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GenerateRandom.Program;

namespace GenerateRandomTests
{
    [TestClass]
    public class GenerateRandomTest
    {
        public void whenCallingGetPseudoRandomNumber_thenNotNull()
        {
            var num = getPseudoRandomNumber();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetPseudoDouble_thenNotNull()
        {
            var num = getPseudoDouble();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGetPseudoRandomNumberThreadSafe_thenNotNull()
        {
            var num = getPseudoRandomNumberThreadSafe();
            Assert.IsNotNull(num);
        }

        [TestMethod]
        public void whenCallingGePseudoRandomString_thenNotNull()
        {
            int count = 100;
            var num = getPseudoRandomString(count);
            Assert.IsNotNull(num);
        }
        [TestMethod]
        public void whenCallingRandomCustomNext_thenNotNull()
        {
            var rc = new RandomCustom();
            var num = rc.Next();
            Assert.IsNotNull(num);
        }
    }
}