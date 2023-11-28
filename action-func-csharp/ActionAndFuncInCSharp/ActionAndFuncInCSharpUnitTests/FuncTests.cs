using ActionAndFuncInCSharp;

namespace ActionAndFuncInCSharpUnitTests
{
    public class FuncTests
    {
        private FakeConsole _console;
        private FuncMethods _funcMethods;

        [SetUp]
        public void Setup()
        {
            _console = new FakeConsole();
            _funcMethods = new FuncMethods(_console);
        }

        [Test]
        public void PrintANumber_ShouldPrint42()
        {
            _funcMethods.PrintANumber();

            Assert.That(_console.Messages.Last(), Is.EqualTo("42"));
        }

        [Test]
        public void SquareANumber_ShouldPrint4()
        {
            _funcMethods.SquareANumber();

            Assert.That(_console.Messages.Last(), Is.EqualTo("4"));
        }

        [Test]
        public void SquareAnotherNumber_ShouldPrint100()
        {
            _funcMethods.SquareAnotherNumber();

            Assert.That(_console.Messages.Last(), Is.EqualTo("100"));
        }

        [Test]
        public void CheckANumber_ShouldPrintFalse()
        {
            _funcMethods.CheckANumber();

            Assert.That(_console.Messages.Last(), Is.EqualTo("False"));
        }
    }
}
