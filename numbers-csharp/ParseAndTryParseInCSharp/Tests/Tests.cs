using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace ParseAndTryParseInCSharp.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GivenIntParse_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(456, Program.IntParse("456"));

            Assert.AreEqual(-4567, Program.IntParse("-4567"));
        }

        [TestMethod]
        public void GivenIntParse_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<FormatException>(() => Program.IntParse("3456.89"));

            Assert.ThrowsException<OverflowException>(() => Program.IntParse("34343454574745"));

            Assert.ThrowsException<ArgumentNullException>(() => Program.IntParse(null));
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenValid_ThenConversionSuccess()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.PositiveSign = "#";

            Assert.AreEqual(1234, Program.IntParse("#1234", culture));
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenInvalid_ThenConversionThrowsException()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.PositiveSign = "#";

            Assert.ThrowsException<FormatException>(() => Program.IntParse("#4567"));

            Assert.ThrowsException<FormatException>(() => Program.IntParse("$4561", culture));

            Assert.ThrowsException<OverflowException>(() => Program.IntParse("#34343454574745", culture));
        }

        [TestMethod]
        public void GivenIntParseStyles_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(3476, Program.IntParse("3476", NumberStyles.None));

            Assert.AreEqual(76678, Program.IntParse("76678.0", NumberStyles.AllowDecimalPoint));

            Assert.AreEqual(766780, Program.IntParse("766,780", NumberStyles.AllowThousands));
        }

        [TestMethod]
        public void GivenIntParseStyles_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<FormatException>(() => Program.IntParse("$45,618", NumberStyles.AllowThousands));

            Assert.ThrowsException<OverflowException>(() => Program.IntParse("56.89", NumberStyles.AllowDecimalPoint));
        }

        [TestMethod]
        public void GivenIntParseFormatStyles_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(78, Program.IntParse("78,000", NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR")));

            Assert.AreEqual(78000, Program.IntParse("78,000", NumberStyles.AllowThousands, new CultureInfo("en-GB")));

            Assert.AreEqual(78, Program.IntParse("78.000", NumberStyles.Float, new CultureInfo("en-US")));
        }

        [TestMethod]
        public void GivenIntParseFormatStyles_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<FormatException>(() => Program.IntParse("$78,000", NumberStyles.Float, new CultureInfo("en-US")));

            Assert.ThrowsException<OverflowException>(() => Program.IntParse("78.567", NumberStyles.AllowDecimalPoint, new CultureInfo("en-US")));
        }

        [TestMethod]
        public void GivenIntParseFormatStylesSpan_WhenValid_ThenConversionSuccess()
        {
            Assert.AreEqual(78, Program.IntParse("78,000".AsSpan(), NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR")));

            Assert.AreEqual(78000, Program.IntParse("78,000".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("en-GB")));

            Assert.AreEqual(78, Program.IntParse("78.000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US")));
        }

        [TestMethod]
        public void GivenIntParseFormatStylesSpan_WhenInvalid_ThenConversionThrowsException()
        {
            Assert.ThrowsException<FormatException>(() => Program.IntParse("$78,000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US")));

            Assert.ThrowsException<OverflowException>(() => Program.IntParse("78.567".AsSpan(), NumberStyles.AllowDecimalPoint, new CultureInfo("en-US")));
        }

        [TestMethod]
        public void GivenIntTryParse_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(Program.IntTryParse("45689", out int result));

            Assert.AreEqual(45689, result);
        }

        [TestMethod]
        public void GivenIntTryParse_WhenInvalid_ThenNoExceptionReturnFalse()
        {
            Assert.IsFalse(Program.IntTryParse("3456.89", out int formatNum));

            Assert.IsFalse(Program.IntTryParse("34343454574745", out int overflowNum));

            Assert.IsFalse(Program.IntTryParse(null, out int nullNum));
        }

        [TestMethod]
        public void GivenIntTryParseFormatStyles_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(Program.IntTryParse("78,000", NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"), out int frNum));

            Assert.AreEqual(78, frNum);

            Assert.IsTrue(Program.IntTryParse("78,000", NumberStyles.AllowThousands, new CultureInfo("en-GB"), out int gbNum));

            Assert.AreEqual(78000, gbNum);

            Assert.IsTrue(Program.IntTryParse("78.000", NumberStyles.Float, new CultureInfo("en-US"), out int usNum));

            Assert.AreEqual(78, usNum);
        }

        [TestMethod]
        public void GivenIntTryParseFormatStyles_WhenInvalid_ThenNoExceptionReturnFalse()
        {
            Assert.IsFalse(Program.IntTryParse("$78,000", NumberStyles.Float, new CultureInfo("en-US"), out int floatNum));

            Assert.IsFalse(Program.IntTryParse("78.567", NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out int decimalNum));
        }

        [TestMethod]
        public void GivenIntTryParseSpan_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(Program.IntTryParse("45689".AsSpan(), out int result));

            Assert.AreEqual(45689, result);
        }

        [TestMethod]
        public void GivenIntTryParseSpan_WhenInvalid_ThenNoExceptionReturnFalse()
        {
            ReadOnlySpan<char> value = null;

            Assert.IsFalse(Program.IntTryParse(value, out int nullNum));

            Assert.IsFalse(Program.IntTryParse("3456.89".AsSpan(), out int formatNum));

            Assert.IsFalse(Program.IntTryParse("34343454574745".AsSpan(), out int overflowNum));
        }

        [TestMethod]
        public void GivenIntTryParseFormatStylesSpan_WhenValid_ThenConversionSuccess()
        {
            Assert.IsTrue(Program.IntTryParse("78,000".AsSpan(), NumberStyles.Float | NumberStyles.AllowThousands, new CultureInfo("fr-FR"), out int frNum));

            Assert.AreEqual(78, frNum);

            Assert.IsTrue(Program.IntTryParse("78,000".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("en-GB"), out int gbNum));

            Assert.AreEqual(78000, gbNum);

            Assert.IsTrue(Program.IntTryParse("78.000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US"), out int usNum));

            Assert.AreEqual(78, usNum);
        }

        [TestMethod]
        public void GivenIntTryParseFormatStylesSpan_WhenInvalid_ThenNoExceptionReturnFalse()
        {
            Assert.IsFalse(Program.IntTryParse("$78,000".AsSpan(), NumberStyles.Float, new CultureInfo("en-US"), out int floatNum));

            Assert.IsFalse(Program.IntTryParse("78.567".AsSpan(), NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out int decimalNum));
        }
    }
}