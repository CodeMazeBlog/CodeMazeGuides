using IndexOutOfRangeExceptionProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IndexOutOfRangeExceptionUnitTest
    {
        private readonly UtilityHelper utilityHelper = new();

        [TestMethod]
        public void WhenExceptionFlagIsTrueForUpperBoundMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.UpperBoundMethod(true);
            };

            Assert.ThrowsException<IndexOutOfRangeException>(testArray);
        }

        [TestMethod]
        public void WhenExceptionFlagIsTrueForCustomLowerBoundMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.CustomLowerBoundMethod(2, true);
            };

            Assert.ThrowsException<IndexOutOfRangeException>(testArray);
        }

        [TestMethod]
        public void WhenExceptionFlagIsTrueAndInvalidSearchArgumentForListIndexOfMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.ListIndexOfMethod(11, true);
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(testArray);
        }

        [TestMethod]
        public void WhenExceptionFlagIsTrueForAssignFirstArrayElementToSecondArrayMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.AssignFirstArrayElementToSecondArrayMethod(true);
            };

            Assert.ThrowsException<IndexOutOfRangeException>(testArray);
        }

        [TestMethod]
        public void WhenExceptionFlagIsTrueForIndexAndValueMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.IndexAndValueMethod(true);
            };

            Assert.ThrowsException<IndexOutOfRangeException>(testArray);
        }

        [TestMethod]
        public void WhenExceptionFlagIsTrueForDataTableMethod_ThenRaiseException()
        {
            var testArray = () =>
            {
                utilityHelper.DataTableMethod(true);
            };

            Assert.ThrowsException<IndexOutOfRangeException>(testArray);
        }
    }
}