using ActionAndFuncInCsharp;

namespace ActionAndFuncInCSharpTest
{
    [TestClass]
    public class ActionAndFuncInCSharpTest
    {
        [TestMethod]
        public void WhenValidInputProvided_ThenPrintsCorrectSum()
        {
            // Arrange       
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            //Act 
            ActionAndFuncInCSharp.AddNumbersDelegate(5, 7);

            // Assert    
            var expectedOutput = "Sum of 5 and 7 is 12";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void WhenZeroValuesProvided_ThenReturnsZeroSum()
        {
            // Arrange   
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            //Act 
            ActionAndFuncInCSharp.AddNumbersDelegate(0, 0);

            //Assert 
            var expectedOutput = "Sum of 0 and 0 is 0";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void WhenPositiveNumberProvided_ThenReturnsCorrectSquare()
        {
            // Act       
            var result = ActionAndFuncInCSharp.SquareDelegate(4);

            //Assert   
            var expectedSquare = 16;
            Assert.AreEqual(expectedSquare, result);
        }

        [TestMethod]
        public void WhenNegativeNumberProvided_ThenReturnsPositiveSquare()
        {
            // Act 
            var result = ActionAndFuncInCSharp.SquareDelegate(-3);

            // Assert   
            var expectedSquare = 9;
            Assert.AreEqual(expectedSquare, result);
        }
    }
}