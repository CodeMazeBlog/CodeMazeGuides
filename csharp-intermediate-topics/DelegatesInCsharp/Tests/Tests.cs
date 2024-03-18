using DelegatesInCsharp;

namespace Tests
{
    public class DelegateExampleTests
    {
        private const string TEXT_IN_UPPER_CASE = "PROGRAMMING DELEGATES IN CSHARP";

        [Fact]
        public void Given_TextInLowerCase_Then_MethodReturnsTextInUpperCase()
        {
            var textInLowerCase = DelegateExample.GetTextInLowercase(TEXT_IN_UPPER_CASE);

            Assert.True(TEXT_IN_UPPER_CASE.ToLower().Equals(textInLowerCase), "Error converting text to lower case.");
        }

        [Fact]
        public void When_HraIsValid_Then_MethodReturnTrue()
        {
            var hra = DelegateExample.GetHra(1000.00);

            Assert.True(hra == 400.00, "Error in hra calculation.");
        }
    }
}