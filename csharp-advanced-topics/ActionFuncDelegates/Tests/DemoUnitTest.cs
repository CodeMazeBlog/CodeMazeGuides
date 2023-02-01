using Xunit;
using ActionFuncDelegates;

namespace Tests
{
    public class DemoUnitTest
    {
        [Fact]
        public void GetAgeMethod_ShouldReturnWholeNumber()
        {
            // Arrange
            DateOnly bday = new DateOnly(1901, 12, 25);

            // Act
            int age = Demo.GetAge(bday);

            // Assert
            Assert.True(age > 0);
        }
    }
}
