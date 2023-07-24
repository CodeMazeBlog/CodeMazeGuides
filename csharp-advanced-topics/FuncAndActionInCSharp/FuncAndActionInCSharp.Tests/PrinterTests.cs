namespace FuncAndActionInCSharp.Tests
{
    public class PrinterTests
    {
        [Fact]
        public void PrintMessage_SingleMessage_PrintsToConsole()
        {
            // ARRANGE
            StringWriter writer = new();
            Console.SetOut(writer);
            Printer printer = new();

            // ACT
            printer.PrintMessage("Hello, world!");

            // ASSERT
            Assert.Equal("Hello, world!", writer.GetStringBuilder().ToString().TrimEnd());
        }

        [Fact]
        public void PrintTwoMessages_TwoMessages_PrintsToConsole()
        {
            // ARRANGE
            StringWriter writer = new();
            Console.SetOut(writer);
            Printer printer = new();

            // ACT
            printer.PrintTwoMessages("Hello,", "world!");

            // ASSERT
            Assert.Equal("Hello, world!", writer.GetStringBuilder().ToString().TrimEnd());
        }
    }
}
