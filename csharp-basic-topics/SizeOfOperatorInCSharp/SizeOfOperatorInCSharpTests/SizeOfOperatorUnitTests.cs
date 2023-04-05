namespace SizeOfOperatorInCSharpTests
{
    [TestClass]
    public class SizeOfOperatorUnitTests
    {
        [TestMethod]
        public void GivenAPrimitiveTypeVerifyAccurateSize()
        {
            Assert.AreEqual(1, sizeof(byte));
            Assert.AreEqual(2, sizeof(short));
            Assert.AreEqual(4, sizeof(int));
            Assert.AreEqual(8, sizeof(long));
            Assert.AreEqual(2, sizeof(char));
            Assert.AreEqual(4, sizeof(float));
            Assert.AreEqual(8, sizeof(double));
            Assert.AreEqual(16, sizeof(decimal));
            Assert.AreEqual(1, sizeof(bool));
        }

        [TestMethod]
        public void GivenTwoPrimitiveTypesCompareSizes()
        {
            Assert.IsTrue(sizeof(byte) < sizeof(short));
            Assert.IsTrue(sizeof(int) == sizeof(float));
            Assert.IsTrue(sizeof(long) == sizeof(double));
            Assert.IsTrue(sizeof(decimal) > sizeof(bool));
        }
    }
}