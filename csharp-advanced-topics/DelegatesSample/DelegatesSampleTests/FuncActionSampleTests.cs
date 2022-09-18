using DelegatesSampleCode;
using Xunit;

namespace DelegatesSampleTests
{
    public class FuncActionSampleTests
    {
        [Fact]
        public void SampleSuccessFullRun()
        {
            var response = FuncActionSample.Sample();
            Assert.True(response);
        }
    }
}