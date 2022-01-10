using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace ParseAndTryParseInCSharp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void GivenIntParse_WhenValidString_ConversionSuccessfull()
        {
            var actual = Program.IntParse("5689");

            Assert.AreEqual(5689, actual);
        }

        [TestMethod]
        public void GivenIntParse_WhenStringWithIncorrectFormat_ResultDefaultValue()
        {
            var actual = Program.IntParse("5689.78");

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParse_WhenStringOverflows_ResultDefaultValue()
        {
            var actualMax = Program.IntParse("7878977879878979");
            var actualMin = Program.IntParse("-75663434345352352");

            Assert.AreEqual(0, actualMax);

            Assert.AreEqual(0, actualMin);
        }

        [TestMethod]
        public void GivenIntParse_WhenStringNull_ResultDefaultValue()
        {
            var actual = Program.IntParse("null");

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenValidString_ConversionSuccessfull()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NegativeSign = "&";

            var actual = Program.IntParse("&5689", culture);

            Assert.AreEqual(-5689, actual);
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenIncorrectFormatString_ResultDefaultValue()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NegativeSign = "&";

            var actual = Program.IntParse("&5689&", culture);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenStringOverflows_ResultDefaultValue()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NegativeSign = "&";

            var actual = Program.IntParse("&56565675675675656757", culture);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseFormat_WhenStringNull_ResultDefaultValue()
        {
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NegativeSign = "&";

            var actual = Program.IntParse("null", culture);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseNumberStyles_WhenValidString_ConversionSuccessfull()
        {
            var actualDecimal = Program.IntParse("456.0", NumberStyles.AllowDecimalPoint);
            var actualThousands = Program.IntParse("45,000", NumberStyles.AllowThousands);

            Assert.AreEqual(456, actualDecimal);

            Assert.AreEqual(45000, actualThousands);
        }

        [TestMethod]
        public void GivenIntParseNumberStyles_WhenStringWithIncorrectFormat_ResultDefaultValue()
        {
            var actualThousands = Program.IntParse("5689.78", NumberStyles.AllowThousands);
            var actualLeading = Program.IntParse("-8976-", NumberStyles.AllowLeadingSign);

            Assert.AreEqual(0, actualThousands);

            Assert.AreEqual(0, actualLeading);
        }

        [TestMethod]
        public void GivenIntParseNumberStyles_WhenStringOverflows_ResultDefaultValue()
        {
            var actualMax = Program.IntParse("3245657636767969", NumberStyles.None);
            var actualMin = Program.IntParse("-75234678956547656", NumberStyles.AllowLeadingSign);

            Assert.AreEqual(0, actualMax);

            Assert.AreEqual(0, actualMin);
        }

        [TestMethod]
        public void GivenIntParseNumberStyles_WhenStringNull_ResultDefaultValue()
        {
            var actual = Program.IntParse("null", NumberStyles.None);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseFormatNumberStyles_WhenValidString_ConversionSuccessfull()
        {
            var actualDecimal = Program.IntParse("45.0000", NumberStyles.AllowThousands, new CultureInfo("es-ES"));
            var actualExponent = Program.IntParse("56E05", NumberStyles.AllowExponent, new CultureInfo("en-US"));

            Assert.AreEqual(450000, actualDecimal);

            Assert.AreEqual(5600000, actualExponent);
        }

        [TestMethod]
        public void GivenIntParseFormatNumberStyles_WhenStringWithIncorrectFormat_ResultDefaultValue()
        {
            var actual = Program.IntParse("56E05", NumberStyles.AllowThousands, new CultureInfo("en-US"));

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseFormatNumberStyles_WhenStringOverflows_ResultDefaultValue()
        {
            var actualMax = Program.IntParse("3245657636767969", NumberStyles.None, new CultureInfo("en-GB"));
            var actualMin = Program.IntParse("-75234678956547656", NumberStyles.AllowLeadingSign, new CultureInfo("en-GB"));

            Assert.AreEqual(0, actualMax);

            Assert.AreEqual(0, actualMin);
        }

        [TestMethod]
        public void GivenIntParseFormatNumberStyles_WhenStringNull_ResultDefaultValue()
        {
            var actual = Program.IntParse("null", NumberStyles.Any, new CultureInfo("en-US"));

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseCharSpan_WhenValidSpan_ConversionSuccessfull()
        {
            var actualDecimal = Program.IntParse("45.0000".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("es-ES"));
            var actualExponent = Program.IntParse("56E05".AsSpan(), NumberStyles.AllowExponent, new CultureInfo("en-US"));

            Assert.AreEqual(450000, actualDecimal);

            Assert.AreEqual(5600000, actualExponent);
        }

        [TestMethod]
        public void GivenIntParseCharSpan_WhenSpanWithIncorrectFormat_ResultDefaultValue()
        {
            var actual = Program.IntParse("323.34".AsSpan(), NumberStyles.AllowThousands, new CultureInfo("en-US"));

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntParseCharSpan_WhenInputOverflows_ResultDefaultValue()
        {
            var actualMax = Program.IntParse("65364257526735672".AsSpan(), NumberStyles.None, new CultureInfo("en-GB"));
            var actualMin = Program.IntParse("-41264437267612565126".AsSpan(), NumberStyles.AllowLeadingSign, new CultureInfo("en-GB"));

            Assert.AreEqual(0, actualMax);

            Assert.AreEqual(0, actualMin);
        }

        [TestMethod]
        public void GivenIntParseCharSpan_WhenStringNull_ResultDefaultValue()
        {
            ReadOnlySpan<char> value = null;
            var actual = Program.IntParse(value, NumberStyles.Any, new CultureInfo("en-US"));

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void GivenIntTryParse_WhenValidString_ReturnTrue()
        {
            var result = Program.IntTryParse("78895", out int actual);

            Assert.IsTrue(result);

            Assert.AreEqual(78895, actual);
        }

        [TestMethod]
        public void GivenIntTryParse_WhenInvalidString_ReturnFalse()
        {
            var resultInCorrectFormat = Program.IntTryParse("$78895", out int actualInCorrectFormat);
            var resultOverFlow = Program.IntTryParse("234567667643567578673564", out int actualOverFlow);
            var resultNull = Program.IntTryParse("null", out int actualNullArg);

            Assert.IsFalse(resultInCorrectFormat);

            Assert.IsFalse(resultOverFlow);

            Assert.IsFalse(resultNull);

            Assert.AreEqual(0, actualInCorrectFormat);

            Assert.AreEqual(0, actualOverFlow);

            Assert.AreEqual(0, actualNullArg);
        }

        [TestMethod]
        public void GivenIntTryParseFormatNumberStyles_WhenValidString_ReturnTrue()
        {
            var result = Program.IntTryParse("$43434", NumberStyles.AllowCurrencySymbol, new CultureInfo("en-US"), out int actual);

            Assert.IsTrue(result);

            Assert.AreEqual(43434, actual);
        }

        [TestMethod]
        public void GivenIntTryParseFormatNumberStyles_WhenInvalidString_ReturnTrue()
        {
            var resultCurrency = Program.IntTryParse("&43434", NumberStyles.AllowCurrencySymbol, new CultureInfo("en-US"), out int actualCurrency);
            var resultOverflow = Program.IntTryParse("-43434213456645", NumberStyles.AllowLeadingSign, new CultureInfo("en-US"), out int actualOverflow);

            Assert.IsFalse(resultCurrency);

            Assert.IsFalse(resultOverflow);

            Assert.AreEqual(0, actualCurrency);

            Assert.AreEqual(0, actualOverflow);
        }

        [TestMethod]
        public void GivenIntTryParse_WhenValidSpan_ReturnTrue()
        {
            var result = Program.IntTryParse("325465".AsSpan(), out int actual);

            Assert.IsTrue(result);

            Assert.AreEqual(325465, actual);
        }

        [TestMethod]
        public void GivenIntTryParse_WhenInvalidSpan_ReturnFalse()
        {
            var resultInCorrectFormat = Program.IntTryParse("$65475".AsSpan(), out int actualInCorrectFormat);
            var resultOverFlow = Program.IntTryParse("-4545656567234656".AsSpan(), out int actualOverFlow);
            var resultNull = Program.IntTryParse(null, out int actualNullArg);

            Assert.IsFalse(resultInCorrectFormat);

            Assert.IsFalse(resultOverFlow);

            Assert.IsFalse(resultNull);

            Assert.AreEqual(0, actualInCorrectFormat);

            Assert.AreEqual(0, actualOverFlow);

            Assert.AreEqual(0, actualNullArg);
        }

        [TestMethod]
        public void GivenIntTryParseFormatNumberStyles_WhenValidSpan_ReturnTrue()
        {
            var result = Program.IntTryParse("34E04".AsSpan(), NumberStyles.AllowExponent, new CultureInfo("en-US"), out int actual);

            Assert.IsTrue(result);

            Assert.AreEqual(340000, actual);
        }

        [TestMethod]
        public void GivenIntTryParseFormatNumberStyles_WhenInvalidSpan_ReturnTrue()
        {
            var resultCurrency = Program.IntTryParse("&23465", NumberStyles.AllowCurrencySymbol, new CultureInfo("en-US"), out int actualCurrency);
            var resultOverflow = Program.IntTryParse("56E78", NumberStyles.AllowExponent, new CultureInfo("en-US"), out int actualOverflow);

            Assert.IsFalse(resultCurrency);

            Assert.IsFalse(resultOverflow);

            Assert.AreEqual(0, actualCurrency);

            Assert.AreEqual(0, actualOverflow);
        }
    }
}