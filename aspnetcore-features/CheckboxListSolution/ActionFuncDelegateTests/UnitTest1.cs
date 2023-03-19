using Xunit;

namespace ActionFuncDelegateTests
{
    public class UnitTest1
    {
        [Fact]
        public void AddWhenGivenThreeNumbersThenReturnTheirSum()
        {
            // Act
            int result = testTestDelegate.Sum(10, 10, 15);

            // Assert
            Assert.Equal(35, result);
        }

        [Fact]
        public void ActionDelegateDisplayTestMessage()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Adress testAdress = new Adress("test adress");
            Action displayMethod = testAdress.DisplayToConsole;
            displayMethod();

            // Assert
            var output = writer.GetStringBuilder().ToString().Trim();
            Assert.Equal("test adress", output);
        }
    }
}