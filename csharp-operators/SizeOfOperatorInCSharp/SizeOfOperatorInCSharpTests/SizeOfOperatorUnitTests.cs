using System.Runtime.InteropServices;

namespace SizeOfOperatorInCSharpTests
{
    public struct MyStruct 
    {
        public byte byteVar;//1
        public int intVar;//4
        public long longVar;//8
        public double doubleVar;//8
        public float floatVar;//4
        public short shortVar;//2
        public char charVar;//2
        public decimal decimalVar;//16
        public bool boolVar;//1
    }

    [TestClass]
    public class SizeOfOperatorUnitTests
    {
        [TestMethod]
        public void GivenAPrimitiveType_WhenSizeofInvoked_VerifyAccurateSize()
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
        public void GivenTwoPrimitiveTypes_WhenSizeofInvoked_CompareSizes()
        {
            Assert.IsTrue(sizeof(byte) < sizeof(short));
            Assert.IsTrue(sizeof(int) == sizeof(float));
            Assert.IsTrue(sizeof(long) == sizeof(double));
            Assert.IsTrue(sizeof(decimal) > sizeof(bool));
        }

        [TestMethod]
        public void GivenAStructType_WhenSizeofInvoked_VerifyAccurateSize()
        {
            var expected = 56;
            var actual = Marshal.SizeOf(typeof(MyStruct));

            Assert.AreEqual(expected, actual);
            Assert.IsInstanceOfType(actual, typeof(int));
        }
    }
}