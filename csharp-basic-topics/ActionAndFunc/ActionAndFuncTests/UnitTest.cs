using ActionAndFunc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ActionAndFuncDelegateTests
{
    [TestClass]
    public class UnitTest
    {
        [TestClass]
        public class ExampleTests
        {
            [TestMethod]
            public void WhenPrintNumbersWithoutAction_ThenNumbersPrintedCorrectly()
            {
                // Arrange
                var numbers = new List<int> { 1, 2, 3, 4, 5 };
                var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                var expectedOutput = "1" + Environment.NewLine +
                                     "2" + Environment.NewLine +
                                     "3" + Environment.NewLine +
                                     "4" + Environment.NewLine +
                                     "5" + Environment.NewLine;

                // Act
                Example.PrintNumbersWithoutAction(numbers);
                var actualOutput = stringWriter.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput, "The printed numbers do not match the expected output.");
            }

            [TestMethod]
            public void WhenPrintNumbersWithAction_ThenNumbersPrintedCorrectly()
            {
                // Arrange
                var numbers = new List<int> { 1, 2, 3, 4, 5 };
                var stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                var expectedOutput = "1" + Environment.NewLine +
                                     "2" + Environment.NewLine +
                                     "3" + Environment.NewLine +
                                     "4" + Environment.NewLine +
                                     "5" + Environment.NewLine;

                // Act
                Example.PrintNumbersWithAction(numbers, Console.WriteLine);
                var actualOutput = stringWriter.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput, "The printed numbers do not match the expected output.");
            }
            [TestMethod]
            public void AddNumbers_WhenValidInputProvided_ReturnsCorrectSum()
            {
                // Arrange
                var expectedSum = 8;
                var a = 5;
                var b = 3;

                // Act
                var actualSum = Example.AddNumbers(a, b);

                // Assert
                Assert.AreEqual(expectedSum, actualSum);
            }
        }
    }
}