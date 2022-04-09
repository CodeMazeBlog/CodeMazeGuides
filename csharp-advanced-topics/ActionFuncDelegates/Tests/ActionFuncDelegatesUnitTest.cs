using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionFuncDelegatesUnitTest
    {
        private static void Subtract(int num1, int num2) { Console.WriteLine(num1 - num2); }

        private static int Multiply(int num1, int num2, int num3) { return num1 * num2 * num3; }

        [TestMethod]
        public void WhenSubstractingTwoNumbers_ThenActionDelegateExecutesCorrectValue()
        {
            Action<int, int> substractNumbers = Subtract;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            substractNumbers(10, 3);
            int expected = 7;

            Assert.AreEqual((expected.ToString() + Environment.NewLine), stringWriter.ToString());
        }

        [TestMethod]
        public void WhenMultiplyingThreeNumbers_ThenFuncDelegateReturnsCorrectValue()
        {
            Func<int, int, int, int> multiplyNumbers = Multiply;

            var result = multiplyNumbers(10, 10, 1);
            int expected = 100;

            Assert.AreEqual(expected, result);
        }
    }
}
