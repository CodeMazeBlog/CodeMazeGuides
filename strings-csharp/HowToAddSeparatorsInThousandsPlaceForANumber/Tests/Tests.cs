using HowToAddSeparatorsInThousandsPlaceForANumber;
using System.Globalization;

namespace Tests
{
    public class Tests
    {
        private readonly CultureInfo _englishCultureInfo = new("en-US");
        private readonly CultureInfo _spanishCultureInfo = new("es-ES");

        [Fact]
        public void GivenNumericValue_WhenStringFormatIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingTheStringFormatMethod();

            Assert.Equal("Your account balance is: 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingTheStringFormatMethodAndACultureInfo(_englishCultureInfo);

            Assert.Equal("Your account balance is: 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoWithoutSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(null, _englishCultureInfo);

            Assert.Equal("Your account balance is: 2,154,002.54", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoAndSpecifierWithDecimalPlacesIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(4, _englishCultureInfo);

            Assert.Equal("Your account balance is: 2,154,002.5350", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringFormatWithCultureInfoAndSpecifierWithoutDecimalPlacesIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingTheStringFormatMethodACultureInfoAndSpecifier(0, _englishCultureInfo);

            Assert.Equal("Your account balance is: 2,154,003", message);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = NumbersFormatting.GetBalanceUsingTheToStringMethod("n", null);

            Assert.Equal("Your account balance is: 2,154,002.54", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierWithDecimalPlacesIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", null);

            Assert.Equal("Your account balance is: 2,154,002.5350", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierWithoutDecimalPlacesIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = NumbersFormatting.GetBalanceUsingTheToStringMethod("n0", null);

            Assert.Equal("Your account balance is: 2,154,003", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenToStringWithSpecifierWithDecimalPlacesAndCultureInfoIsUsed_ShouldReturnExpectedStringValue()
        {
            var formattedBallance = NumbersFormatting.GetBalanceUsingTheToStringMethod("n4", _spanishCultureInfo);

            Assert.Equal("Your account balance is: 2.154.002,5350", formattedBallance);
        }

        [Fact]
        public void GivenNumericValue_WhenStringInterpolationWitboutSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingStringInterpolation(null);

            Assert.Equal("Your account balance is: 2154002.535", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringInterpolationWithSpecifierIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingStringInterpolation(4);

            Assert.Equal("Your account balance is: 2,154,002.5350", message);
        }

        [Fact]
        public void GivenNumericValue_WhenStringInterpolationWithSpecifierAndCultureInfoIsUsed_ShouldReturnExpectedStringValue()
        {
            var message = NumbersFormatting.GetBalanceUsingStringInterpolationWithCultureInfo("n4", _spanishCultureInfo);

            Assert.Equal("Your account balance is: 2.154.002,5350", message);
        }
    }
}