using ITextMergingPDFs.ConsoleManager;

namespace Tests
{
    [TestClass]
    public class IConsoleWrapperTest
    {
        private FakeConsole _console = default!;

        [TestInitialize]
        public void Initialize()
        {
            _console = new FakeConsole();
        }

        [TestMethod]
        public void GivenEmptyConsole_WhenUsingConsole_ThenExpectZeroLines()
        {
            Assert.AreEqual(0, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenConsole_WhenUsingClear_ThenExpectZeroLines()
        {
            _console.Write("message");
            _console.Clear();

            Assert.AreEqual(0, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenMessage_WhenUsingWrite_ThenExpectOneLine()
        {
            _console.Write("message");

            Assert.AreEqual(1, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenFewMessages_WhenUsingWrite_ThenExpectOneLine()
        {
            for (var i = 0; i < 10; i++)
                _console.Write("message");

            Assert.AreEqual(1, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenMessage_WhenUsingWriteLine_ThenExpectOneLine()
        {
            _console.WriteLine("message");

            Assert.AreEqual(1, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenFewMessages_WhenUsingWriteLine_ThenExpectFewLine()
        {
            var numberOfLines = 10;

            for (var i = 0; i < numberOfLines; i++)
                _console.WriteLine("message");

            Assert.AreEqual(numberOfLines, _console.NumberOfLines);
        }

        [TestMethod]
        public void GivenConsoleWithoutKeys_WhenUsingGetKey_ThenExpectException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _console.ReadKey());
        }

        [TestMethod]
        public void GivenConsoleWithKeys_WhenUsingGetKey_ThenThisKeys()
        {
            List<ConsoleKeyInfo> pressedKeys = new()
            {
                new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false),
                new ConsoleKeyInfo('x', ConsoleKey.X, false, false, false),
                new ConsoleKeyInfo('k', ConsoleKey.K, false, false, false),
                new ConsoleKeyInfo('7', ConsoleKey.D3, false, false, false)
            };

            var console = new FakeConsole(pressedKeys);

            for (var i = 0; i < pressedKeys.Count; i++)
            {
                var key = console.ReadKey();

                Assert.AreEqual(pressedKeys[i].Key, key.Key);
                Assert.AreEqual(pressedKeys[i].KeyChar, key.KeyChar);
                Assert.AreEqual(pressedKeys[i].Modifiers, key.Modifiers);
            }
            Assert.ThrowsException<InvalidOperationException>(() => console.ReadKey());
        }
    }
}
