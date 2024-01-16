using StringTruncationInCSharp;

namespace StringTruncationInCSharpTests
{
    public class StringTruncationTests
    {
        private const int MaxLength = 10;
        private const string OriginalString = "This is a long string.";
        private const int MaxLengthLessThanZero = -10;
        private const string ExpectedTruncatedString = "This is a ";

        [Fact]
        public void WhenTruncatingAString_ThenUseSubstringMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithSubstring(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseForLoopMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoop(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }
        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseForLoopMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoop(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseForLoopMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoop(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseForLoopMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithForLoop(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseForLoopMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithForLoop(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithForLoopStringBuilder(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseRegularExpressionsMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }
        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithRegularExpressions(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseRemoveMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithRemove(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithRemove(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithRemove(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithRemove(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithRemove(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseLINQMethodToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithLINQ(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }



        [Fact]
        public void WhenTruncatingAString_ThenUseSpanToTruncateTheString()
        {
            var truncatedString = StringHelper.TruncateWithSpan(OriginalString, MaxLength);

            Assert.Equal(ExpectedTruncatedString, truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithSpan(OriginalString, OriginalString.Length);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
        {
            var truncatedString = StringHelper.TruncateWithSpan(OriginalString, OriginalString.Length + 10);

            Assert.Equal(OriginalString, truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithSpan(OriginalString, 0);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
        {
            var truncatedString = StringHelper.TruncateWithSpan(OriginalString, MaxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }
    }
}