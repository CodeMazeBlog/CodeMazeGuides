using FindTheMaximumValue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly int[] sourceArray = new int[] { 3, 7, 23, 40, 37, 9, 19 };
        private readonly ElementFinder _elementFinder = new();

        [TestMethod]
        public void GivenTheClassProgram_ThenRunTheMainMethodAndWriteResultsAtTheConsole()
        {
            Program.Main(Array.Empty<string>());
                        
            Assert.AreEqual(1, Program.OutputResult);
        }

        [TestMethod]
        public void GivenAnSourceArray_ThenReturnTheMaximumElementUsingTheMethodGetLargestElementUsingMax()
        {
            var largestElement = _elementFinder.GetLargestElementUsingMax(sourceArray);

            Assert.AreEqual(40, largestElement);
        }

        [TestMethod]
        public void GivenAnSourceArray_ThenReturnTheMaximumElementUsingTheMethodGetLargestElementUsingOrderByDescending()
        {
            var largestElement = _elementFinder.GetLargestElementUsingOrderByDescending(sourceArray);

            Assert.AreEqual(40, largestElement);
        }

        [TestMethod]
        public void GivenAnSourceArray_ThenReturnTheMaximumElementUsingTheMethodGetLargestElementUsingMaxBy()
        {
            var largestElement = _elementFinder.GetLargestElementUsingMaxBy(sourceArray);

            Assert.AreEqual(40, largestElement);
        }

        [TestMethod]
        public void GivenAnSourceArray_ThenReturnTheMaximumElementUsingTheMethodGetLargestElementUsingFor()
        {
            var largestElement = _elementFinder.GetLargestElementUsingFor(sourceArray);

            Assert.AreEqual(40, largestElement);
        }
    }
}