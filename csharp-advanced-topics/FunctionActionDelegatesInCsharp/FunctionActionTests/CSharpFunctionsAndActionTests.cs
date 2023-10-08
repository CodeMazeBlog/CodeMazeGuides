using FunctionActionDelegatesInCsharp;

namespace FunctionActionTests
{
    [TestClass]
    public class CSharpFunctionsAndActionTests
    {
        [TestMethod]
        public void Given_Two_Numbers_When_Added_Then_Result_Should_Be_Correct()
        {
            //arrange
            var numberToSubtract = 2;
            var numberSubtracted = 1;
            var expectedResult = 1;
            //act
            var resultAdd = FunctionAction.Subtract(numberToSubtract, numberSubtracted);

            //assert
            Assert.AreEqual(expectedResult, resultAdd);
        }

        [TestMethod]
        public void Given_A_Number_When_Printing_Even_Then_Number_Should_Be_Printed()
        {
            //arrange
            var numberToPrint = 42;
            Action<int> action = Console.WriteLine;
            //act
            FunctionAction.PrintEven(numberToPrint, action);
            //assert
        }
    }
}