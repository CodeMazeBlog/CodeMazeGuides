using StringTruncationInCSharp;

namespace StringTruncationInCSharpTests
{
    public class StringTruncationTests
    {
        private readonly int _maxLength = 10;
        private readonly string _originalString = "This is a long string.";
        private StringHelper _stringHelper;
        public StringTruncationTests()
        {
            _stringHelper = new StringHelper();
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseSubstringMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingSubstring(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseLoopMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingForLoop(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseStringBuilderMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingStringBuilder(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseRegularExpressionsMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingRegularExpressions(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseRemoveMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingRemove(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }

        [Fact]
        public void WhenTruncatingAString_ThenUseLINQMethod()
        {
            var truncatedString = _stringHelper.TruncateStringUsingLINQ(_originalString, _maxLength);

            Assert.Equal("This is a ", truncatedString);
        }
    }
}