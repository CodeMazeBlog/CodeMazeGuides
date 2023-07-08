using ActionAndFuncDelegateInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.ActionAndFuncDelegateInCSharp
{
    [TestClass]
    public class ActionAndFuncTests
    {

        [TestMethod]
        public void WhenFirstNameAndLastNameProvided_DelegateReturnsFullName()
        {
            //Arrange
            DelegatesDefinition delegatesDefinition = new();
            Func<string, string, string> getFullNameDelegate = delegatesDefinition.GetFullName;
            var firstName = "Code";
            var lastName = "Maze";

            //Act
            var result = getFullNameDelegate.Invoke(firstName, lastName);

            //Assert
            Assert.AreEqual($"{firstName} {lastName}", result);
        }

        [TestMethod]
        public void WhenTwoNumbersProvided_DelegateReturnsSum()
        {
            //Arrange
            DelegatesDefinition delegatesDefinition = new();
            Action<int, int> getSumofNumbers = delegatesDefinition.GetSumOfNumbers;
            var firstNumber = 5;
            var secondNumber = 10;

            //Act
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            getSumofNumbers.Invoke(firstNumber, secondNumber);
            var expectedResult = firstNumber + secondNumber;

            //Assert
            Assert.AreEqual(expectedResult.ToString().Trim(), stringWriter.ToString().Trim());
        }
    }
}
