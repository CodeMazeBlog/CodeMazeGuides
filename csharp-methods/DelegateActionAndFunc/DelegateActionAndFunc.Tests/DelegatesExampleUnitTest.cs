namespace DelegateActionAndFunc.Tests
{
    public class DelegatesExampleUnitTest
    {
        private static DelegatesExample DelegateExample => new();

        [Fact]
        public void WhenTestingAction_ThenShowStringWriterMessage()
        {
            // Arrange
            string expectedMessage = "Hello world";
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DelegateExample.showMessage("Hello world");

            // Assert
            string resultMessage = sw.ToString().Trim();
            Assert.Equal(expectedMessage, resultMessage);
        }

        [Fact]
        public void WhenTestingFunc_ThenShowAddResult()
        {
            // Arrange
            int expectedResult = 10;

            // Act
            int result = DelegateExample.Add(2, 8);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}