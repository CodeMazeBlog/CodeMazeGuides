using ActionAndFuncDelegate.Action;
using System.Text;

namespace ActionAndFuncDelegate.Test
{
    public class Action
    {
   
        [Fact]
        public void WhenParameterIs10_ThenTheValueShouldBeMessageWith10()
        {
            // Arrange
            var expectedOutput = "The article number is: 10" + Environment.NewLine;
            var consoleOutput = new StringBuilder();
            var stringWriter = new StringWriter(consoleOutput);
            Console.SetOut(stringWriter);

            // Act
            ActionDelegateExample.ActionDelegate();
            string actualOutput = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}