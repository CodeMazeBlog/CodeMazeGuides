using ActionFuncDelegates;

namespace Tests
{
    [TestClass]
    public class ActionFuncTest
    {
        [TestMethod]
        public void ActionFunc_WhenAddOperation_ThenOutputForAdd()
        {
            int a = 6; 
            int b = 3;
            int result = 9;

            Assert.AreEqual(result, FuncActionDemo.Calculate(a, b, MathOperation.Add));
            
        }
        [TestMethod]
        public void ActionFunc_WhenSubtractOperation_ThenOutputForSubtract()
        {
            int a = 6;
            int b = 3;
            int result = 3;

            Assert.AreEqual(result, FuncActionDemo.Calculate(a, b, MathOperation.Subtract));

        }
        [TestMethod]
        public void ActionFunc_WhenMultiplyOperation_ThenOutputForMultiply()
        {
            int a = 6;
            int b = 3;
            int result = 18;

            Assert.AreEqual(result, FuncActionDemo.Calculate(a, b, MathOperation.Multiply));

        }
        [TestMethod]
        public void ActionFunc_WhenDivideOperation_ThenOutputForDivide()
        {
            int a = 6;
            int b = 3;
            int result = 2;

            Assert.AreEqual(result, FuncActionDemo.Calculate(a, b, MathOperation.Divide));

        }
    }
}