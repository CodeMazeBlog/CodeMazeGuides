using System.Text;

namespace Tests
{
    public class ActionFunctionDelegatesUnitTest
    {
        [Fact]
        public void DisplayName_ShouldPrintName()
        {// Arrange
            var expectedOutput = "My name is Bob";
            var output = string.Empty;
            var stringBuilder = new StringBuilder();
            Console.SetOut(new StringWriter(stringBuilder));

            // Act
            Action<string> displayNameAct = Program.DisplayName;
            displayNameAct("Bob");
            output = stringBuilder.ToString().Trim();

            // Assert
            Assert.Equal(expectedOutput, output);
        }
        [Fact]
        public void NumberToString_ShouldConvertNumberToString()
        {
            // Arrange
            var number = 4;
            var expectedOutput = "4";

            // Act
            Func<int, string> toStringFunc = Program.NumberToString;
            var result = toStringFunc(number);

            // Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void NumberToDouble_ShouldConvertNumberToDouble()
        {
            // Arrange
            var number = 4;
            var expectedOutput = 4.0;

            // Act
            Func<int, double> toDoubleFunc = Program.NumberToDouble;
            var result = toDoubleFunc(number);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}
