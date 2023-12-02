using System.Globalization;

namespace Tests
{
    public class Tests
    {
        private readonly double _balance = 2154002.535;
        private readonly CultureInfo _englishCultureInfo = new("en-US");
        private readonly CultureInfo _spanishCultureInfo = new("es-ES");

        // String.Format method
        [Fact]
        public void GivenNumericValue_WhenStringFormatIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = String.Format("Your account balance is {0}", _balance);

            Assert.Equal("Your account balance is 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = String.Format("Your account balance is {0}", _balance, _englishCultureInfo);

            Assert.Equal("Your account balance is 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoAndNumericSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = String.Format("Your account balance is {0:n}", _balance, _englishCultureInfo);

            Assert.Equal("Your account balance is 2,154,002.54", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoNumericSpecifierAndDecimalCountIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = String.Format("Your account balance is {0:n4}", _balance, _englishCultureInfo);

            Assert.Equal("Your account balance is 2,154,002.5350", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoNumericSpecifierAndDecimalCount0IsUsed_ShouldReturnExpectedStringValue()
        {
            var message = String.Format("Your account balance is {0:n0}", _balance, _englishCultureInfo);

            Assert.Equal("Your account balance is 2,154,003", message);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = _balance.ToString("n");

            Assert.Equal("2,154,002.54", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierAndDigitCountIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = _balance.ToString("n4");

            Assert.Equal("2,154,002.5350", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierAndDigitCount0IsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = _balance.ToString("n0");

            Assert.Equal("2,154,003", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierAndDigitCountAndCultureInfoIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = _balance.ToString("n4", _spanishCultureInfo);

            Assert.Equal("2.154.002,5350", formattedBallance);
        }

        // Interpolation
        [Fact]
        public void GivenNumericValue_WhenStringInterpolationIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = $"Your account balance is {_balance}";

            Assert.Equal("Your account balance is 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringInterpolationIsUsedWithSpecifier_ShouldReturnExpectedStringValue()
        {
            var message = $"Your account balance is {_balance:n4}";

            Assert.Equal("Your account balance is 2,154,002.5350", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringInterpolationIsUsedWithSpecifierAndCultureInfo_ShouldReturnExpectedStringValue()
        {
            var message = $"Your account balance is {_balance.ToString("n4", _spanishCultureInfo)}";

            Assert.Equal("Your account balance is 2.154.002,5350", message);
        }
    }
}