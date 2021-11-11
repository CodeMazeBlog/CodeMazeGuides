
using ActionFuncDelegatesCsharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        #region GenericDelegateTests

        [TestMethod]
        public void WhenFirstNameAndLastNameProvided_GenericDelegateReturnsFullName()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Func<string, string, string> delegateFullName = understandingDelegates.GetFullName;
            var firstName = "Code";
            var lastName = "Maze";

            //Act
            var result = delegateFullName.Invoke(firstName, lastName);

            //Assert
            Assert.AreEqual($"{firstName} {lastName}", result);
        }

        [TestMethod]
        public void WhenTwoNumbersProvided_GenericDelegateReturnsSum()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Action<int, int> delegatePrintSumOfNumbers = understandingDelegates.PrintSumOfNumbers;
            var firstNumber = 5;
            var secondNumber = 10;

            //Act
            using StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            delegatePrintSumOfNumbers.Invoke(firstNumber, secondNumber);
            var expectedResult = firstNumber + secondNumber;

            //Assert
            Assert.AreEqual(expectedResult.ToString().Trim(), stringWriter.ToString().Trim());
        }



        [TestMethod]
        public void GivenAString_WhenLengthGreaterThanTenAndGenericDelegatePredicateUsed_ReturnTrue()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Predicate<string> delegateCheckLengthOfString = understandingDelegates.CheckLengthOfString;
            var randomString = "CodeMazeBlogs";

            //Act
            var result = delegateCheckLengthOfString.Invoke(randomString);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAString_WhenLengthLessThanTenAndGenericDelegatePredicateUsed_ReturnFalse()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Predicate<string> delegateCheckLengthOfString = understandingDelegates.CheckLengthOfString;
            var randomString = "CodeMaze";

            //Act
            var result = delegateCheckLengthOfString.Invoke(randomString);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenAString_WhenLengthGreaterThanTenAndGenericDelegateFuncUsed_ReturnTrue()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Func<string, bool> delegateCheckLengthOfString = understandingDelegates.CheckLengthOfString;
            var randomString = "CodeMazeBlogs";

            //Act
            var result = delegateCheckLengthOfString.Invoke(randomString);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenAString_WhenLengthLessThanTenAndGenericDelegateFuncUsed_ReturnFalse()
        {
            //Arrange
            UnderstandingDelegates understandingDelegates = new UnderstandingDelegates();
            Func<string, bool> delegateCheckLengthOfString = understandingDelegates.CheckLengthOfString;
            var randomString = "CodeMaze";

            //Act
            var result = delegateCheckLengthOfString.Invoke(randomString);

            //Assert
            Assert.IsFalse(result);
        }


        #endregion
    }
}
