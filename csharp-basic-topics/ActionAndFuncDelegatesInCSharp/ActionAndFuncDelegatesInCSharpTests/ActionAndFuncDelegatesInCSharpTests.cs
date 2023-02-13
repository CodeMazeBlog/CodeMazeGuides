using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class ActionAndFuncDelegatesInCSharpTests : IDisposable
    {

        private readonly StringWriter output = new();

        public ActionAndFuncDelegatesInCSharpTests()
        {
            Console.SetOut(output);
        }

        public void Dispose()
        {
            output.Dispose();
            GC.SuppressFinalize(this);
        }

        public string[] PrintedOutputToArray()
        {
            var printedString = output.ToString();
            return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Theory]
        [InlineData("")]
        [InlineData(default)]
        public void WhenMessageIsInvalud_ThenArgumentExceptionIsThrown(string message)
        {
            // Arrange
            var action = () => Program.PrintMessage(message);

            // Act
            var exception = Assert.Throws<ArgumentException>(action);

            // Assert
            Assert.Equal("message cannot be NULL or empty", exception.Message);
        }

        [Fact]
        public void WhenMessageIsCorrect_ThenProductsArePrinted()
        {
            // Act
            Program.Main();

            var result = PrintedOutputToArray();

            Assert.Equal("Laptop 999.95 (1002.05 incl. VAT)", result[0]);
            Assert.Equal("Car 15000 (15000.14 incl. VAT)", result[1]);
            Assert.Equal("TV 599 (602.51 incl. VAT)", result[2]);
        }
    }
}