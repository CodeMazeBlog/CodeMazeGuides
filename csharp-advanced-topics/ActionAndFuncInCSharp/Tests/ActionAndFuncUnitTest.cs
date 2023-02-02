using ActionAndFuncInCSharp;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncUnitTest
    {
        [TestMethod]
        public void WhenStringIsSent_ThenActionExecutesTheReferencedMethod()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            Action<string> executeNamedAction = new Action<string>(Program.WriteText);

            executeNamedAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenStringIsSent_ThenActionExecutesTheReferencedShorterMethod()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            Action<string> executeNamedAction = Program.WriteText;

            executeNamedAction("Action delegate in CSharp");

            string expectedResult = "Text: Action delegate in CSharp";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void WhenStringIsSent_ThenActionExecutesTheAnonymousMethod()
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
        public void WhenStringIsSent_ThenActionExecutesTheLambdaMethod()
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
        public void WhenStringIsSent_ThenFuncExecutesTheReferencedMethod()
        {
            Func<string, string> executeNamedFunc = new Func<string, string>(Program.Reverse);

            string result = executeNamedFunc("Func delegate in CSharp");

            string expectedResult = Program.Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void WhenStringIsSent_ThenFuncExecutesTheReferencedShorterMethod()
        {
            Func<string, string> executeNamedFunc = Program.Reverse;

            string result = executeNamedFunc("Func delegate in CSharp");

            string expectedResult = Program.Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WhenStringIsSent_ThenFuncExecutesTheAnonymousMethod()
        {
            Func<string, string> executeAnonymousFunc
                = delegate (string text) {
                    return Program.Reverse(text);
                };

            string result = executeAnonymousFunc("Func delegate in CSharp");

            string expectedResult = Program.Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WhenStringIsSent_ThenFuncExecutesTheLambdaMethod()
        {
            Func<string, string> executeLambdaFunc
                = text => Program.Reverse(text);

            string result = executeLambdaFunc("Func delegate in CSharp");

            string expectedResult = Program.Reverse("Func delegate in CSharp");

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenMultipleDelegate_WhenTwoLambaMethodAndPlusSign_ThenChainActionExecutesTheMethods()
        {
            using var sw = new StringWriter();
            sw.NewLine = "";
            Console.SetOut(sw);

            Action executeChainAction = () => Program.WriteText("Call Number One");
            executeChainAction += () => Program.WriteText("Call Number Two");
            executeChainAction += () => Program.WriteText("Call Number Three");

            executeChainAction();

            string expectedResult = "Text: Call Number OneText: Call Number TwoText: Call Number Three";

            Assert.AreEqual(expectedResult, sw.ToString());
        }

        [TestMethod]
        public void GivenMultipleDelegate_WhenTwoLambaMethodAndPlusSign_ThenChainFuncReturnsLastValue()
        {
            Func<string> executeChainFunc = () => Program.Reverse("Call Number One");
            executeChainFunc += () => Program.Reverse("Call Number Two");
            executeChainFunc += () => Program.Reverse("Call Number Three");

            var result = executeChainFunc();

            string expectedResult = Program.Reverse("Call Number Three");

            Assert.AreEqual(expectedResult, result);
        }

    }
}