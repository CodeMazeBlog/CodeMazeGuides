using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumUpArrayElements;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly SumArrayElements _sumArrayElements = new();
        private readonly int[] sourceArray = new int[] { 3, 4, 8, 1, 6, 2 };

        [TestMethod]
        public void GivenTheMainProgram_WhenExecuteTheMainMethod_ThenSetTheOutputResultToOne()
        {
            Program.Main(Array.Empty<string>());

            Assert.AreEqual(1, Program.OutPutResult);
        }

        [TestMethod]
        public void GivenASourceArray_WhenUsingTheForLoopMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.ForLoop(sourceArray);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void GivenASouceArray_WhenUsingTheForeachLoopMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.ForeachLoop(sourceArray);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void GivenASouceArray_WhenUsingArrayForEachMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.ArrayForEach(sourceArray);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void GivenASourceArray_WhenUsingEnumerableSumMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.EnumerableSum(sourceArray);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void GivenASourceArray_WhenUsingTheArraySumMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.ArraySum(sourceArray);

            Assert.AreEqual(24, result);
        }

        [TestMethod]
        public void GivenASourceArray_WhenUsingAggregateMethod_ThenReturnTheSumOfTheElements()
        {
            var result = _sumArrayElements.Aggregate(sourceArray);

            Assert.AreEqual(24, result);
        }
    }
}