using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
   

    public class ActionDelegatesTests
    {
        [Fact]
        public void ActionDelegate_ShouldWriteToConsole()
        {
            // Arrange
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Act
                ActionDelegates.ActionDelegate();

                // Assert
                string expectedOutput = "Add Inputs: 30" + Environment.NewLine + "Subtract Inputs: 10" + Environment.NewLine;
                Assert.Equal(expectedOutput, consoleOutput.ToString());
            }
        }

        [Fact]
        public void ActionDelegateWithAnonymous_ShouldWriteToConsole()
        {
            // Arrange
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Act
                ActionDelegates.ActionDelegateWithAnonymous();

                // Assert
                string expectedOutput = "Subtract = 20" + Environment.NewLine;
                Assert.Equal(expectedOutput, consoleOutput.ToString());
            }
        }

        [Fact]
        public void ActionDelegateWithLambda_ShouldWriteToConsole()
        {
            // Arrange
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);

                // Act
                ActionDelegates.ActionDelegateWithLambda();

                // Assert
                string expectedOutput = "Result: 10" + Environment.NewLine;
                Assert.Equal(expectedOutput, consoleOutput.ToString());
            }
        }
    }

}
