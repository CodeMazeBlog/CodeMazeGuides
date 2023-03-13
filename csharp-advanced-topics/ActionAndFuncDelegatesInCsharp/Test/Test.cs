namespace Test
{
    [TestClass]
    public class Test
    {
        delegate string DisplayDetails(string name);

        static string DisplayName(string name)
        {
          return name;
        }
        [TestMethod]
        public void WhenActionDelegateCalled_WithParameter_ThenDelegate_ShouldExecute()
        {
            Action<string> actionDelegate = ActionWithParameter;
            var invocation = actionDelegate.GetInvocationList();
            Assert.AreEqual(invocation.Length, 1);
        }
        [TestMethod]
        public void WhenActionDelegateCalled_WithAnonymousMethod_ThenDelegate_ShouldExecute()
        {
            Action<string> delegateWithAnonymousMethod = delegate (string message)
            {
                Console.WriteLine(message);
            };
            var invocation = delegateWithAnonymousMethod.GetInvocationList();
            Assert.AreEqual(invocation.Length, 1);
        }

        [TestMethod]
        public void WhenActionDelegateCalled_WithLambda_ThenDelegate_ShouldExecute()
        {
            Action<int> printNumber = Number => Console.WriteLine(Number);

            var invocation = printNumber.GetInvocationList();
            Assert.AreEqual(invocation.Length, 1);
        }


        #region func unit test
        [TestMethod]
        public void WhenFuncDelegatesWithParams_ThenDelegate_ShouldExecute()
        {
            string testString = "steve";
            Func<string, string> funcDelegateWithParams = getName;
            var name = getName(testString);

            Assert.AreEqual(testString, name);
        }

        [TestMethod]
        public void WhenFunDelegateCalled_WithAnonymousMethod_ThenDelegate_ShouldExecute()
        {
            Func<int> showNumber = delegate () { int no = 5; return no; };
            var invocation = showNumber.GetInvocationList();
            Assert.AreEqual(invocation.Length, 1);
        }
        [TestMethod]
        public void WhenFunDelegateCalled_WithLambda_ThenDelegate_ShouldExecute()
        {
            Func<int, int> square = no => no * no;
            var invocation = square.GetInvocationList();
            Assert.AreEqual(invocation.Length, 1);
        }
        #endregion
        #region Methods

        public static void ActionWithParameter(string name)
        {
            Console.WriteLine($"{name}");
        }

        public static string getName(string name)
        {
            return name;
        }
        #endregion
    }
}