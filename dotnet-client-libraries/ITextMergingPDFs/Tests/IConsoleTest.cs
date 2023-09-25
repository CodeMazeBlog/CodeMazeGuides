using ITextMergingPDFs.ConsoleManager;

namespace Tests
{
    [TestClass]
    public class IConsoleTest
    {
        [TestMethod]
        public void GivenEmptyConsole_WhenUsingConsole_ThenExpectZeroLines()
        {
            var console = new FakeConsole();

            Assert.AreEqual(0, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenConsole_WhenUsingClear_ThenExpectZeroLines()
        {
            var console = new FakeConsole();

            console.Write("message");
            console.Clear();

            Assert.AreEqual(0, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenMessage_WhenUsingWrite_ThenExpectOneLine()
        {
            var console = new FakeConsole();

            console.Write("message");

            Assert.AreEqual(1, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenFewMessages_WhenUsingWrite_ThenExpectOneLine()
        {
            var console = new FakeConsole();

            for (int i = 0; i < 10; i++)
                console.Write("message");

            Assert.AreEqual(1, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenMessage_WhenUsingWriteLine_ThenExpectOneLine()
        {
            var console = new FakeConsole();

            console.WriteLine("message");

            Assert.AreEqual(1, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenFewMessages_WhenUsingWriteLine_ThenExpectFewLine()
        {
            var console = new FakeConsole();
            int numberOfLines = 10;

            for (int i = 0; i < numberOfLines; i++)
                console.WriteLine("message");

            Assert.AreEqual(numberOfLines, console.NumberOfLines);
        }

        [TestMethod]
        public void GivenConsoleWithoutKeys_WhenUsingGetKey_ThenExpectException()
        {
            var console = new FakeConsole();

            Assert.ThrowsException<InvalidOperationException>(() => console.ReadKey());
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

            for (int i = 0; i < pressedKeys.Count; i++)
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
