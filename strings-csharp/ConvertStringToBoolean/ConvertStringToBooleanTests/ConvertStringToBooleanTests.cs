using ConvertStringToBoolean;
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

            Assert.AreEqual(true, Convert.ToBoolean("TRUE"));

            Assert.AreEqual(true, Convert.ToBoolean("    true   "));

            Assert.AreEqual(false, Convert.ToBoolean("false"));

            Assert.AreEqual(false, Convert.ToBoolean("False"));

            Assert.AreEqual(false, Convert.ToBoolean("    false   "));

            Assert.AreEqual(false, Convert.ToBoolean("False   "));

            Assert.AreEqual(false, Convert.ToBoolean(null));
        }

        [TestMethod]
        public void GivenConvertToBoolean_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean(""));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean(string.Empty));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("t"));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("y"));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("yes"));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("  yes "));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("-1"));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("0"));

            Assert.ThrowsExactly<FormatException>(() => Convert.ToBoolean("1"));
        }

        [TestMethod]
        public void GivenboolParse_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(true, bool.Parse("true"));

            Assert.AreEqual(true, bool.Parse("True"));

            Assert.AreEqual(true, bool.Parse("TRUE"));

            Assert.AreEqual(true, bool.Parse("    true   "));

            Assert.AreEqual(false, bool.Parse("false"));

            Assert.AreEqual(false, bool.Parse("False"));

            Assert.AreEqual(false, bool.Parse("    false   "));

            Assert.AreEqual(false, bool.Parse("False   "));
        }

        [TestMethod]
        public void GivenboolParse_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => bool.Parse(null));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse(""));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse(string.Empty));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("t"));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("y"));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("yes"));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("  yes "));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("-1"));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("0"));

            Assert.ThrowsExactly<FormatException>(() => bool.Parse("1"));
        }

        [TestMethod]
        public void GivenboolTryParse_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(bool.TryParse("true", out bool result1));

            Assert.AreEqual(true, result1);

            Assert.IsTrue(bool.TryParse("TRUE", out bool result2));

            Assert.AreEqual(true, result2);

            Assert.IsTrue(bool.TryParse("   true  ", out bool result3));

            Assert.AreEqual(true, result3);

            Assert.IsTrue(bool.TryParse("false", out bool result4));

            Assert.AreEqual(false, result4);

            Assert.IsTrue(bool.TryParse("False", out bool result5));

            Assert.AreEqual(false, result5);

            Assert.IsTrue(bool.TryParse("   false  ", out bool result6));

            Assert.AreEqual(false, result6);
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

            Assert.IsFalse(bool.TryParse("y", out bool result4));

            Assert.IsFalse(result4);

            Assert.IsFalse(bool.TryParse("yes", out bool result5));

            Assert.IsFalse(result5);

            Assert.IsFalse(bool.TryParse("-1", out bool result6));

            Assert.IsFalse(result6);

            Assert.IsFalse(bool.TryParse("0", out bool result7));

            Assert.IsFalse(result7);

            Assert.IsFalse(bool.TryParse("1", out bool result8));

            Assert.IsFalse(result8);
        }

        [TestMethod]
        public void GivenToBoolOrNull_WhenRecognisedTrueText_ThenReturnsTrue()
        {
            Assert.AreEqual(true, StringToBoolean.ToBoolOrNull("1"));

            Assert.AreEqual(true, StringToBoolean.ToBoolOrNull("yes"));

            Assert.AreEqual(true, StringToBoolean.ToBoolOrNull("Y"));

            Assert.AreEqual(true, StringToBoolean.ToBoolOrNull("  ON  "));
        }

        [TestMethod]
        public void GivenToBoolOrNull_WhenRecognisedFalseText_ThenReturnsFalse()
        {
            Assert.AreEqual(false, StringToBoolean.ToBoolOrNull("0"));

            Assert.AreEqual(false, StringToBoolean.ToBoolOrNull("no"));

            Assert.AreEqual(false, StringToBoolean.ToBoolOrNull("off"));
        }

        [TestMethod]
        public void GivenToBoolOrNull_WhenUnrecognisedText_ThenReturnsNull()
        {
            Assert.IsNull(StringToBoolean.ToBoolOrNull(null));

            Assert.IsNull(StringToBoolean.ToBoolOrNull("maybe"));
        }
    }
}
