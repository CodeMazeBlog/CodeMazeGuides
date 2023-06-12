using Func_and_Action_Delegates;

namespace FuncTest
{
    public class CalculatorTest
    {
        private Calculator _calculator { get; set; } = null!;
        private CalculatorWrapper _calculatorWrapper { get; set; } = null!;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
            _calculatorWrapper = new CalculatorWrapper(_calculator.Add);
        }

        [Test]
        public void Add_Test()
        {
            //Assign

            var number1 = 6;
            var number2 = 7;
           

            //Act
           var result =  _calculatorWrapper.Add(number1, number2);
            //Assert

            Assert.That(result, Is.EqualTo(13));
            
        }

        [Test]
        public void Add_CustomFunc()
        {
            // Arrange
            Func<int, int, int> customFunc = (a, b) => a + b;
           

            // Act
            int result = _calculatorWrapper.Add(4, 6);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
    }
}