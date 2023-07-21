namespace Tests
{
    public class ActionDelegateException : Exception
    {
        public ActionDelegateException(string message) : base(message)
        {
        }
    }

    [TestClass]
    public class ActionDelegateTests
    {
        Action<int, int, string> LogOperation = (int x, int y, string operation) =>
        {
            switch (operation)
            {
                case "+":
                    LogInfo("Sum is: " + (x + y)); break;
                case "-":
                    LogInfo("Diff is: " + (x - y)); break;
                case "*":
                    LogInfo("Result is: " + (x * y)); break;
                case "/":
                    LogInfo("Division Result is: " + (x / y)); break;
                default:
                    LogInfo("Operation not supported!"); break;
            }
        };
        public static void LogInfo(string message) { throw new ActionDelegateException(message); }

        /// <summary>
        /// To test a void return method we throw an exception to dedect action invoked
        /// </summary>
        [TestMethod]
        public void WhenActionDelegateInvoked_ThenActionDelegateExceptionMustThrow()
        {
            Assert.ThrowsException<ActionDelegateException>(() =>
            {
                LogOperation(2, 3, "+");
            });
        }
    }
}