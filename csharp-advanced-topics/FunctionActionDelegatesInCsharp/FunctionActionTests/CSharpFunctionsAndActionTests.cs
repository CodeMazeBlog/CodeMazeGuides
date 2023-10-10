using FunctionActionDelegatesInCsharp;

namespace FunctionActionTests
{
    [TestClass]
    public class CSharpFunctionsAndActionTests
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenAddedThen_ResultShouldBeCorrect()
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
        public void GivenANumber_WhenPrintingEven_ThenNumberShouldBePrinted()
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