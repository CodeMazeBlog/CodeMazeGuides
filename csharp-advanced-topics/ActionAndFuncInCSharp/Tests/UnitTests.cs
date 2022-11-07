using Xunit;

namespace ActionAndFuncDemo.Tests
{
    
    public class BusinessClassTests
    {
        [Fact]
        public void GetMyMessage_Test()
        {
            var result = BusinessClass.GetMyMessage("Hi", "Hello");
            Assert.NotNull(result);
            Assert.Equal($"You Said: Hi Hello", result);
        }

    }

    public class NumberExtensionTests
    {
        [Fact]
        public void IsPrime_Test_Positive()
        {
            var num = 17;
            Assert.True(num.IsPrime());
        }

        [Fact]
        public void IsPrime_Test_Negative()
        {
            var num = 20;
            Assert.False(num.IsPrime());
        }

    }
}