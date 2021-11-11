using FuncAndActionDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class FuncAndActionDelegatesUnitTest
    {
        [TestMethod]
        public void GivenNegativeAndPositiveNumbers_WhenLINQAbsoluteSelectorViaFuncIsCalled_ThenAllNumbersHaveAbsoluteValues()
        {
            // Given
            var numbers = new int[] { 0, 1, -2, 3, -4, 5, 6 };
            // When
            var absoluteNumbers = numbers
                .Select(x => x < 0 ? -x : x)
                .ToArray();

            // Then
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6 }, absoluteNumbers);
        }

        [TestMethod]
        public void GivenNegativeAndPositiveNumbers_WhenAbsoluteSelectorWithoutFuncIsCalled_ThenAllNumbersHaveAbsoluteValues()
        {
            // Given
            var numbers = new int[] { 0, 1, -2, 3, -4, 5, 6 };
            // When
            var absoluteNumbersWithoutFunc = numbers
                .Select(new AbsoluteSelector())
                .ToArray();
            // Then
            CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6 }, absoluteNumbersWithoutFunc);
        }

        [TestMethod]
        public void GivenNegativeAndPositiveNumbers_WhenLINQSignSelectorViaFuncIsCalled_ThenAllNumbersHaveSignValues()
        {
            // Given
            var numbers = new int[] { 0, 1, -2, 3, -4, 5, 6 };
            // When
            var signNumbers = numbers
                .Select(x => x < 0 ? -1 : x > 0 ? 1 : 0)
                .ToArray();
            // Then
            CollectionAssert.AreEqual(new int[] { 0, 1, -1, 1, -1, 1, 1 }, signNumbers);
        }

        [TestMethod]
        public void GivenNegativeAndPositiveNumbers_WhenSignSelectorWithoutWithoutFuncIsCalled_ThenAllNumbersHaveSignValues()
        {
            // Given
            var numbers = new int[] { 0, 1, -2, 3, -4, 5, 6 };
            // When
            var signNumbersWithoutFunc = numbers
                .Select(new SignSelector())
                .ToArray();
            // Then
            CollectionAssert.AreEqual(new int[] { 0, 1, -1, 1, -1, 1, 1 }, signNumbersWithoutFunc);
        }

        [TestMethod]
        public void GivenMulticastLoggerAction_WhenLogged_ThenAllReferencedActionsAreInvoked()
        {
            // Given
            var counter = 0;
            Action<string> logger = (message) => {
                var log = $"Message from first logger: {message}";
                counter++;
                // Send log somewhere
            };
            logger += (message) => {
                var log = $"Message from second logger: {message}";
                counter++;
                // Send log somewhere
            };
            // When
            Example.Log(logger, "Please log me!");
            // Then
            Assert.AreEqual(2, counter);
        }

        [TestMethod]
        public void GivenContravariantActions_ThenTheyCanBeReferenced()
        {
            // Given
            Action<object> contravarianceExample = (x) => {
                var exampleVariable = x;
            };

            // Then
            Action<string> x = contravarianceExample;

            Assert.AreEqual(x, contravarianceExample);
        }

    }
}
