using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    public class ActionAndFuncDelegateUnitTest
    {
        [Fact]
        public void whenFuncDelegate_ExecuteTheMethod()
        {
            //Arrange
            Func<int, int, int> calculatorFunc = Calculator.Multiply;
            int a = 2;
            int b = 3;

            //Act
            calculatorFunc(a, b);
            
            //Assert
            Assert.Equal(6, calculatorFunc(a,b));
        }

        [Fact]
        public void whenActionDelegate_ExecuteTheMethod()
        {
            //Arrange
            var expectedOutput = "Our world";
            Action<string> displayMessage = Display.DisplayText;

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            displayMessage(expectedOutput);
            var outPut = stringWriter.ToString();

            //Assert
            Assert.Equal(expectedOutput, outPut);

        }
    }
}
