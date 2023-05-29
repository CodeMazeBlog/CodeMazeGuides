
using ActionAndFuncDelegatesInCSharp;
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
            public void PrintNumbersWithoutAction_PrintsNumbersCorrectly()
            {
                // Arrange
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
                StringWriter stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                string expectedOutput = "1\r\n2\r\n3\r\n4\r\n5\r\n";

                // Act
                Example.PrintNumbersWithoutAction(numbers);
                string actualOutput = stringWriter.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }
            [TestMethod]
            public void PrintNumbersWithAction_PrintsNumbersCorrectly()
            {
                // Arrange
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
                StringWriter stringWriter = new StringWriter();
                Console.SetOut(stringWriter);
                string expectedOutput = "1\r\n2\r\n3\r\n4\r\n5\r\n";
                Action<int> printNumber = Console.WriteLine;

                // Act
                Example.PrintNumbersWithAction(numbers, printNumber);
                string actualOutput = stringWriter.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput);
            }

        }
    }
}