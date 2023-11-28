using ActionAndFuncInCSharp;

namespace ActionAndFuncInCSharpUnitTests
{
    public class ActionTests
    {
        private FakeConsole _console;
        private ActionMethods _actionMethods;

        [SetUp]
        public void Setup()
        {
            _console = new FakeConsole();
            _actionMethods = new ActionMethods(_console);
        }

        [Test]
        public void PrintAMessage_ShouldPrintHello()
        {
            _actionMethods.PrintAMessage();

            Assert.That(_console.Messages.Last(), Is.EqualTo("Hello"));
        }

        [Test]
        public void PrintAMessage_ShouldPrintCustomGreeting()
        {
            _actionMethods.PrintAHelloMessage();

            Assert.That(_console.Messages.Last(), Is.EqualTo("Hello, Code Maze!"));
        }

        [Test]
        public void PrintAMessage_ShouldPrintMoreGreetings()
        {
            _actionMethods.PrintMoreHelloMessages();

            Assert.That(_console.Messages.First(), Is.EqualTo("Hello, Bob!"));
            Assert.That(_console.Messages.Last(), Is.EqualTo("Hello, Mary!"));
        }
    }
}