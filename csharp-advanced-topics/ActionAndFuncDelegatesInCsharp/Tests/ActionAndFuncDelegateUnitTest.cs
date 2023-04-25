using ActionAndFuncDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ActionAndFuncDelegateUnitTest
    {
        [Fact]
        public void whenActionDelegate_ExecuteTheMethod()
        {
            //Arrange
            var calculator = new Calculator();
            Func<int, int, int> calculatorFunc = Calculator.Multiply;
            int a = 2;
            int b = 3;

            //Act
            calculatorFunc(a, b);
            
            //Assert
            Assert.Equal(6, calculatorFunc(a,b));
        }

        [Fact]
        public void whenFuncDelegate_ExecuteTheMethod()
        {
            //Arrange
            var expectedOutput = "WARAP\r\n";
            Action<string> displayMessage = Display.DisplayText;

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            displayMessage("WARAP");
            var outPut = stringWriter.ToString();

            //Assert
            Assert.Equal(expectedOutput, outPut);

        }
    }
}
