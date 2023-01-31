namespace Tests
{
    [TestClass]
    public class ActionAndFuncUnitTest
    {
        static void WriteText(string text) => Console.Write($"Text: {text}");
        static string ReverseText(string text) => Reverse(text);

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        [TestMethod]
        public void WhenStringIsSent_ActionExecutesTheReferencedMethod()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Action<string> executeNamedAction = new Action<string>(WriteText);

            executeNamedAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }
        [TestMethod]
        public void WhenStringIsSent_ActionExecutesTheReferencedShorterMethod()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Action<string> executeNamedAction = WriteText;

            executeNamedAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }


        [TestMethod]
        public void WhenStringIsSent_ActionExecutesTheAnonymousMethod()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Action<string> executeAnonymousAction 
                = delegate (string text) {
                    Console.Write($"Text: {text}");
                };

            executeAnonymousAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenStringIsSent_ActionExecutesTheLambdaMethod()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Action<string> executeLambdaAction
                = text => Console.Write($"Text: {text}");

            executeLambdaAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenStringIsSent_FuncExecutesTheReferencedMethod()
        {
            Func<string, string> executeNamedFunc = new Func<string, string>(ReverseText);

            string result = executeNamedFunc("Func delegate in CSharp");

            string expectedResult = Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void WhenStringIsSent_FuncExecutesTheReferencedShorterMethod()
        {
            Func<string, string> executeNamedFunc = ReverseText;

            string result = executeNamedFunc("Func delegate in CSharp");

            string expectedResult = Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WhenStringIsSent_FuncExecutesTheAnonymousMethod()
        {
            Func<string, string> executeAnonymousFunc
                = delegate (string text) {
                    return Reverse(text);
                };

            string result = executeAnonymousFunc("Func delegate in CSharp");

            string expectedResult = Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WhenStringIsSent_FuncExecutesTheLambdaMethod()
        {
            Func<string, string> executeLambdaFunc
                = text => ReverseText(text);

            string result = executeLambdaFunc("Func delegate in CSharp");

            string expectedResult = Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenMultipleDelegate_WhenTwoLambaMethodAndPlusSign_ChainActionExecutesTheMethods()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Action executeChainAction = () => WriteText("Call Number One");
            executeChainAction += () => WriteText("Call Number Two");
            executeChainAction += () => WriteText("Call Number Three");

            executeChainAction();

            string expectedResult = "Text: Call Number OneText: Call Number TwoText: Call Number Three";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void GivenMultipleDelegate_WhenTwoLambaMethodAndPlusSign_ChainFuncReturnsLastValue()
        {
            Func<string> executeChainFunc = () => ReverseText("Call Number One");
            executeChainFunc += () => ReverseText("Call Number Two");
            executeChainFunc += () => ReverseText("Call Number Three");

            var result = executeChainFunc();

            string expectedResult = Reverse("Call Number Three");

            Assert.AreEqual(expectedResult, result);
        }

    }
}