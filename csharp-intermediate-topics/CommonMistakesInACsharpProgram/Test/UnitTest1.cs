using CommonMistakesInACsharpProgram;
using Xunit;

namespace Test
{
    public class UnitTest1
    {       
        [Fact]
        public void GivenMisplaceTypes_WhenExecuted_ReturnsBool()
        {
            var result = Application.MisplaceTypes();
            Assert.IsType<bool>(result);
        }

        [Fact]
        public void GivenOverLookingExtensionTypes_WhenExecutedWithTrueOrFalse_ReturnsString()
        {
            var result = Application.OverLookingExtensionTypes();
            Assert.IsType<string>(result);
        }

        [Fact]
        public void GivenStringConcantenation_WhenExecutedWithTrueOrFalse_ReturnsString()
        {
            var result = Application.StringConcantenation();
            Assert.IsType<string>(result);
        }
    }
}