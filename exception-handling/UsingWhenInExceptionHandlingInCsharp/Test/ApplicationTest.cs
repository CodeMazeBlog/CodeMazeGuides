using System;
using UsingWhenInExceptionHandlingInCsharp;
using Xunit;

namespace Test
{
    public class ApplicationTest
    {

        [Theory]
        [InlineData("True")]
        [InlineData("False")]
        public void GivenConvertToBool_WhenExecutedWithTrueOrFalse_ReturnsBool(string text)
        {
            var result = Application.ConvertToBool(text);

            Assert.IsType<bool>(result);
        }

        [Theory]
        [InlineData("Any")]
        [InlineData("Other text")]
        public void GivenConvertToBool_WhenExecutedWithoutTrueOrFalse_ReturnsException(string text)
        {
            Assert.Throws<FormatException>(() => Application.ConvertToBool(text));
        }

        [Theory]
        [InlineData("1One")]
        [InlineData("Two2")]
        public void GivenConvertToInt_WhenExecutedWithoutNumbers_ReturnsException(string text)
        {
            Assert.Throws<FormatException>(() => Application.ConvertToInt(text));
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("00000")]
        public void GivenConvertToInt_WhenExecutedWithNumbers_ReturnsInt(string text)
        {
            var result = Application.ConvertToInt(text);

            Assert.IsType<Int32>(result);
        }

        [Theory]
        [InlineData("50CC9E7C-D44B-48FF-947F-B7745F5E6B5")]
        [InlineData("885639C4-BA29-4E86-AAEF-CCE2781B323")]
        public void GivenConvertToGuid_WhenExecutedWithoutCorrectSequence_ReturnsException(string text)
        {
            Assert.Throws<FormatException>(() => Application.ConvertToGuid(text));
        }

        [Theory]
        [InlineData("50CC9E7C-D44B-48FF-947F-B774E5F5E6B5")]
        [InlineData("885639C4-BA29-4E86-AAEF-CCE27F81B323")]
        public void GivenConvertToGuid_WhenExecutedWithCorrectSequence_ReturnsGuid(string text)
        {
            var result = Application.ConvertToGuid(text);
            Assert.IsType<Guid>(result);
        }

        [Theory]
        [InlineData("Friday, April 10, 2009")]
        [InlineData("Saturday, October 24, 1998")]
        public void GivenConvertToDateTime_WhenExecutedWithCorrectDateSequence_ReturnsDateTime(string text)
        {
            var result = Application.ConvertToDateTime(text);

            Assert.IsType<DateTime>(result);
        }

        [Theory]
        [InlineData("Friday, 10 April, 2009")]
        [InlineData("Saturday, 24 October, 1998")]
        public void GivenConvertToDateTime_WhenExecutedWithoutCorrectDateSequence_ReturnsException(string text)
        {
            Assert.Throws<FormatException>(() => Application.ConvertToDateTime(text));
        }
    }

}