using ActionAndFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncInCSharpTests
{
    [TestClass]
    public class ActionAndFuncUnitTests
    {
        [TestMethod]
        public void TestAddNumbersDelegate()
        {
            // Arrange
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);
            //Act 
            ActionAndFuncInCSharp.AddNumbersDelegate(5, 7);
            //Assert   
            string expectedOutput = "Sum of 5 and 7 is 12"; Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void TestSquareDelegate()
        {
            // Act       
            int result = ActionAndFuncInCSharp.SquareDelegate(4);
            //Assert    
            int expectedSquare = 16; Assert.AreEqual(expectedSquare, result);
        }

        [TestMethod]
        public void TestAddNumbersDelegate_WhenValidInputProvided_ThenPrintsCorrectSum()
        {
            // Arrange       
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            //Act 
            ActionAndFuncInCSharp.AddNumbersDelegate(5, 7);

            // Assert    
            string expectedOutput = "Sum of 5 and 7 is 12"; 
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void TestAddNumbersDelegate_WhenZeroValuesProvided_ThenPrintsZeroSum()
        {
            // Arrange   
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            //Act 
            ActionAndFuncInCSharp.AddNumbersDelegate(0, 0);

            //Assert 
            string expectedOutput = "Sum of 0 and 0 is 0"; 
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void TestSquareDelegate_WhenPositiveNumberProvided_ThenReturnsCorrectSquare()
        {
            // Act       
            int result = ActionAndFuncInCSharp.SquareDelegate(4);
            //Assert   
            int expectedSquare = 16;
            Assert.AreEqual(expectedSquare, result);
        }

        [TestMethod]
        public void TestSquareDelegate_WhenNegativeNumberProvided_ThenReturnsPositiveSquare()
        {
            // Act 
            int result = ActionAndFuncInCSharp.SquareDelegate(-3);

            // Assert   
            int expectedSquare = 9;
            Assert.AreEqual(expectedSquare, result);
        }
    }
}
