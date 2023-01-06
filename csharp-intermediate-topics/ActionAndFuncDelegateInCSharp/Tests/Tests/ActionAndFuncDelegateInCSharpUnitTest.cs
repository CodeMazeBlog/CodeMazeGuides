using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Tests
{
    public class ActionAndFuncDelegateInCSharpUnitTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(11)]
        [InlineData(111)]
        public void GivenFuncDelegate_WhenWritingFuncDelegate_ThenReturnNumberWithFormat(int input)
        {
            Func<int, string> funcExample = x => string.Format("{0:n0}", x);
            var output = funcExample(input);

            Assert.Equal(input, Convert.ToInt32(output));
        }
    }
}