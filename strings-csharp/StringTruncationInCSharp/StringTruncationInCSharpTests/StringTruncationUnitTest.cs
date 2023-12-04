using StringTruncationInCSharp;

namespace StringTruncationInCSharpTests
{
    public class StringTruncationTests
    {
        private readonly int _maxLengthEqualToGivenStringLength = 22;
        private readonly int _maxLengthLessThanZero = -10;
        private readonly int _maxLengthEqualToZero = 0;
        private readonly int _maxLengthGreaterThanGivenStringLength = 30;
        private readonly int _maxLength = 10;
        private readonly string _originalString = "This is a long string.";
        private StringHelper _stringHelper;
        public StringTruncationTests()
        {
            _stringHelper = new StringHelper();
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseSubstringMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSubstring(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSubstring(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSubstringMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSubstring(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithSubstring(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSubstringMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithSubstring(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseForLoopMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoop(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }
        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseForLoopMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoop(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseForLoopMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoop(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseForLoopMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoop(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseForLoopMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoop(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoopStringBuilder(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoopStringBuilder(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoopStringBuilder(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoopStringBuilder(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseForLoopWithStringBuilderMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithForLoopStringBuilder(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseRegularExpressionsMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRegularExpressions(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }
        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRegularExpressions(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRegularExpressions(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithRegularExpressions(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRegularExpressionsMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithRegularExpressions(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseRemoveMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRemove(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRemove(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseRemoveMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithRemove(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithRemove(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseRemoveMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithRemove(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }


        [Fact]
        public void WhenTruncatingAString_ThenUseLINQMethodToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithLINQ(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithLINQ(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseLINQMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithLINQ(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithLINQ(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseLINQMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithLINQ(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }



        [Fact]
        public void WhenTruncatingAString_ThenUseSpanToTruncateTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSpan(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void GivenALengthEqualToTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSpan(_originalString, _maxLengthEqualToGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenALengthGreaterThanTheStringLength_WhenTruncatingAString_ThenUseSpanMethodWithoutTruncatingTheString()
        {
            var truncatedString = _stringHelper.TruncateWithSpan(_originalString, _maxLengthGreaterThanGivenStringLength);

            Assert.Equal("This is a long string.", truncatedString);
        }

        [Fact]
        public void GivenAZeroLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithSpan(_originalString, _maxLengthEqualToZero);

            Assert.Equal(string.Empty, truncatedString);
        }

        [Fact]
        public void GivenANonPositiveLength_WhenTruncatingAString_ThenUseSpanMethodAndReturnAnEmptyString()
        {
            var truncatedString = _stringHelper.TruncateWithSpan(_originalString, _maxLengthLessThanZero);

            Assert.Equal(string.Empty, truncatedString);
        }
    }
}