namespace Tests
{
    delegate string MyDelegate(string msg);

    [TestClass]
    public class Tests
    {
        public static string Display(string msg) => $"{msg}";

        [TestMethod]
        public void whenDelegateInvoke_DelegateIsNotEmpty()
        {
            MyDelegate myDelegate = new MyDelegate(Display);
            var result = myDelegate.Invoke("Hello World");
            Assert.AreEqual("Hello World", result);
        }

        [TestMethod]
        public void whenActionDelegate_DelegateInvocationListNotEmpty()
        {
            Action<int> actionDelegate = (result) =>
            {
                Console.WriteLine($"The result of the addition is: {result}");
            };

            Assert.AreEqual(actionDelegate.GetInvocationList().Length, 1);
        }

        [TestMethod]
        public void whenFuncDelegate_DelegateInvocationListNotEmpty()
        {
            Func<string, string> executeReverseWriteAction = Display;
            var invocationList = executeReverseWriteAction.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}