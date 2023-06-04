using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConvertStringToBooleanTests
{
    [TestClass]
    public class ConvertStringToBooleanTests
    {
        [TestMethod]
        public void GivenConvertToBoolean_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(true, Convert.ToBoolean("true"));

            Assert.AreEqual(true, Convert.ToBoolean("True"));

            Assert.AreEqual(false, Convert.ToBoolean("    false   "));

            Assert.AreEqual(false, Convert.ToBoolean("False   "));

            Assert.AreEqual(false, Convert.ToBoolean(null));
        }

        [TestMethod]
        public void GivenConvertToBoolean_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean(""));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean(string.Empty));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean("t"));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean("  yes "));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean("-1"));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean("0"));

            Assert.ThrowsException<FormatException>(() => Convert.ToBoolean("1"));
        }

        [TestMethod]
        public void GivenboolParse_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(true, bool.Parse("true"));

            Assert.AreEqual(true, bool.Parse("True"));

            Assert.AreEqual(false, bool.Parse("    false   "));

            Assert.AreEqual(false, bool.Parse("False   "));
        }

        [TestMethod]
        public void GivenboolParse_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => bool.Parse(null));

            Assert.ThrowsException<FormatException>(() => bool.Parse(""));

            Assert.ThrowsException<FormatException>(() => bool.Parse(string.Empty));

            Assert.ThrowsException<FormatException>(() => bool.Parse("t"));

            Assert.ThrowsException<FormatException>(() => bool.Parse("  yes "));

            Assert.ThrowsException<FormatException>(() => bool.Parse("-1"));

            Assert.ThrowsException<FormatException>(() => bool.Parse("0"));

            Assert.ThrowsException<FormatException>(() => bool.Parse("1"));
        }

        [TestMethod]
        public void GivenboolTryParse_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(bool.TryParse("true", out bool result1));

            Assert.AreEqual(true, result1);

            Assert.IsTrue(bool.TryParse("True", out bool result2));

            Assert.AreEqual(true, result2);

            Assert.IsTrue(bool.TryParse("   false  ", out bool result3));

            Assert.AreEqual(false, result3);

            Assert.IsTrue(bool.TryParse("   False  ", out bool result4));

            Assert.AreEqual(false, result4);
        }

        [TestMethod]
        public void GivenboolTryParse_WhenInvalid_ThenNoExceptionReturnFalse()
        {
            Assert.IsFalse(bool.TryParse(null, out bool result1));

            Assert.IsFalse(result1);

            Assert.IsFalse(bool.TryParse("", out bool result2));

            Assert.IsFalse(result2);

            Assert.IsFalse(bool.TryParse("t", out bool result3));

            Assert.IsFalse(result3);

            Assert.IsFalse(bool.TryParse("  yes  ", out bool result4));

            Assert.IsFalse(result4);

            Assert.IsFalse(bool.TryParse("-1", out bool result5));

            Assert.IsFalse(result5);

            Assert.IsFalse(bool.TryParse("0", out bool result6));

            Assert.IsFalse(result6);

            Assert.IsFalse(bool.TryParse("1", out bool result7));

            Assert.IsFalse(result7);
        }
    }
}
