using AutoFixture;
using HowToValidateGuid;

namespace HowToValidateGuidTests
{
    [TestClass]
    public class GuidHelperTests
    {
        private IFixture _fixture;
        private const string formatKey = "D";

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
        }

        #region ValidateWithRegex

        [TestMethod]
        public void WhenValidateWithRegexCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            Validate(input, GuidHelper.ValidateWithRegex, false);
        }

        [TestMethod]
        public void WhenValidateWithRegexCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            Validate(input, GuidHelper.ValidateWithRegex, true);
        }

        [TestMethod]
        public void WhenValidateWithRegexCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            Validate(input, GuidHelper.ValidateWithRegex, false);
        }

        #endregion

        #region ValidateWithGuidParse

        [TestMethod]
        public void WhenValidateWithGuidParseCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            Validate(input, GuidHelper.ValidateWithGuidParse, false);
        }

        [TestMethod]
        public void WhenValidateWithGuidParseCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            Validate(input, GuidHelper.ValidateWithGuidParse, true);
        }

        [TestMethod]
        public void WhenValidateWithGuidParseCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            Validate(input, GuidHelper.ValidateWithGuidParse, false);
        }

        #endregion

        #region ValidateWithGuidParseExact

        [TestMethod]
        public void WhenValidateWithGuidParseExactCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidParseExact, false);
        }

        [TestMethod]
        public void WhenValidateWithGuidParseExactCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidParseExact, true);
        }

        [TestMethod]
        public void WhenValidateWithGuidParseExactCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidParseExact, false);
        }

        #endregion

        #region ValidateWithGuidTryParse

        [TestMethod]
        public void WhenValidateWithGuidTryParseCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            Validate(input, GuidHelper.ValidateWithGuidTryParse, false);
        }

        [TestMethod]
        public void WhenValidateWithGuidTryParseCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            Validate(input, GuidHelper.ValidateWithGuidTryParse, true);
        }

        [TestMethod]
        public void WhenValidateWithGuidTryParseCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            Validate(input, GuidHelper.ValidateWithGuidTryParse, false);
        }

        #endregion

        #region ValidateWithGuidTryParseExact

        [TestMethod]
        public void WhenValidateWithGuidTryParseExactCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidTryParseExact, false);
        }

        [TestMethod]
        public void WhenValidateWithGuidTryParseExactCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidTryParseExact, true);
        }

        [TestMethod]
        public void WhenValidateWithGuidTryParseExactCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            ValidateFormat(input, formatKey, GuidHelper.ValidateWithGuidTryParseExact, false);
        }

        #endregion

        #region ValidateWithNewGuid

        [TestMethod]
        public void WhenValidateWithNewGuidCalled_ForARandomString_ThenResultMustBeFalse()
        {
            var input = _fixture.Create<string>() + _fixture.Create<string>();

            Validate(input, GuidHelper.ValidateWithNewGuid, false);
        }

        [TestMethod]
        public void WhenValidateWithNewGuidCalled_ForAGuidString_ThenResultMustBeTrue()
        {
            var input = _fixture.Create<Guid>().ToString();

            Validate(input, GuidHelper.ValidateWithNewGuid, true);
        }

        [TestMethod]
        public void WhenValidateWithNewGuidCalled_ForAEmptyString_ThenResultMustBeFalse()
        {
            var input = string.Empty;

            Validate(input, GuidHelper.ValidateWithNewGuid, false);
        }

        #endregion

        private void Validate(string input, Func<string, bool> action, bool expected)
        {
            var result = action(input);

            Assert.AreEqual(expected, result);
        }

        private void ValidateFormat(string input, string format, Func<string, string, bool> action, bool expected)
        {
            var result = action(input, format);

            Assert.AreEqual(expected, result);
        }
    }
}