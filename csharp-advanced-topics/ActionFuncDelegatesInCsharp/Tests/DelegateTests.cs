namespace Tests
{
    [TestClass]
    public class DelegateTests
    {
        public delegate int LengthFinder(string message);
        public static int GetTextLength(string text) { return !string.IsNullOrEmpty(text) ? text.Length : 0; }

        [TestMethod]
        public void WhenDelegateInvokedWithMessage_ThenReferenceMethodMustBeCalled()
        {
            var delegate1 = new LengthFinder(GetTextLength);
            var result = delegate1("test message");
            var expected = 12;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDelegateInvokedWithNoMessage_ThenResultMustBeZero()
        {
            var delegate1 = new LengthFinder(GetTextLength);

            var text = (string)null;
            var result = delegate1(text);
            var expected = 0;

            Assert.AreEqual(expected, result);
        }
    }
}