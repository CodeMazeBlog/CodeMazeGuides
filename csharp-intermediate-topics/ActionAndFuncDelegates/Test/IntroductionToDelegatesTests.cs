using IntroductionToDelegates;
using Xunit;

namespace Test
{
    public class IntroductionToDelegatesTests
    {
        [Fact]
        public void InvokeSayHiViaDelegate_Should_Invoke_SayHi()
        {
            // Arrange
            string expectedResult = Program.SayHi();
            // Act
            string actualResult = Program.InvokeSayHiWithDelegate();
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
