using ActionAndFuncDelegate.Func;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate.Test
{
    public class Func
    {
        [Fact]
        public void WhenValuesAre3And5_ThenOutPutIs8()
        {
            // Arrange
            int expectedSum = 8;
            var consoleOutput = new StringBuilder();
            var stringWriter = new StringWriter(consoleOutput);
            Console.SetOut(stringWriter);

            // Act
            FuncDelegateExample.FuncDelegate();
            string actualOutput = consoleOutput.ToString();

            // Assert
            Assert.Contains("The result of adding 5 and 3 is: " + expectedSum, actualOutput);
        }
    }
}
