using DelegatesSampleCode;
using Xunit;

namespace DelegatesSampleTests
{
    public class GeneralDelegateSampleTests
    {
        [Fact]
        public void SampleSuccessFullRun()
        {
            var response = GeneralDelegateSample.Sample();
            Assert.True(response);
        }
    }
}
