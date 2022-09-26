using DelegatesSampleCode;
using Xunit;

namespace DelegatesSampleTests
{
    public class FuncActionSampleTests
    {
        [Fact]
        public void SampleSuccessFullRun()
        {
            var response = FuncActionSample.SampleAction();
            Assert.True(response);
        }

        [Fact]
        public void SampleSuccessFunc()
        {
            var response = FuncActionSample.SampleFunc();
            Assert.True(response>0);
        }
    }
}