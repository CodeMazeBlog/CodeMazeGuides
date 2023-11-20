using ActionAndFuncDelegates;

namespace Tests
{
    public class Tests
    {
        Calculator _calculator;
        CalculatorInputs _calculatorInputs;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _calculatorInputs = new CalculatorInputs();
        }

        [Test]
        public void Test1()
        {
            _calculatorInputs.Choice = 1;
            _calculatorInputs.First = 10;
            _calculatorInputs.Second = 20;

            _calculator.Run(_calculatorInputs);
            var foo = _calculator.FuncDelegate(10, 20);

            Assert.IsTrue(foo == 30);
//            Assert.AreEqual(foo, 300);
        }
    }
}