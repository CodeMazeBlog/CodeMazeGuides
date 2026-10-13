using HowToMergeArrays;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly MergeArrayBenchmark _mergeArrayRunner;
        private readonly int _combinedExpectedSize;
        private readonly int _combinedExpectedSizeDistinct;

        private readonly int[] first;
        private readonly int[] second;
        private readonly int[] _expectedMerged;
        private readonly int[] _expectedDistinct;

        public Tests()
        {
            _mergeArrayRunner = new MergeArrayBenchmark();
            var source = _mergeArrayRunner.GetSourceArrayPopulatedWithNumbers().Single();
            first = (int[])source[0];
            second = (int[])source[1];

            _combinedExpectedSize = _mergeArrayRunner.ArraySize * 2;
            _combinedExpectedSizeDistinct = _mergeArrayRunner.ArraySize + _mergeArrayRunner.ArraySize / 2;

            // The expected results are built without any of the methods under test:
            // every element of the first array, then every element of the second.
            var expected = new List<int>(first);
            expected.AddRange(second);
            _expectedMerged = expected.ToArray();

            // The second array starts halfway through the first, so the distinct values run
            // from 0 to one and a half times the array size, in first-seen order.
            _expectedDistinct = Enumerable.Range(0, _combinedExpectedSizeDistinct).ToArray();
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndNewArray_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithNewArray(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndResize_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithResize(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndResize_ThenFirstArrayIsLeftUnchanged()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithResize(first, second);

            Assert.NotSame(first, combinedArray);
            Assert.Equal(_mergeArrayRunner.ArraySize, first.Length);
        }

        [Fact]
        public void WhenMergingWithArrayCopyTo_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyTo(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithSpanCopyTo_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingSpanCopyTo(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithLinqConcat_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqConcat(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithLinqUnion_ThenCombinedArrayHoldsEachDistinctValueOnce()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqUnion(first, second);

            Assert.Equal(_combinedExpectedSizeDistinct, combinedArray.Length);
            Assert.Equal(_expectedDistinct, combinedArray);
        }

        [Fact]
        public void WhenMergingWithLinqSelectMany_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqSelectMany(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithCollectionExpression_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingCollectionExpression(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithBlockCopy_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingBlockCopy(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }

        [Fact]
        public void WhenMergingWithNewArrayManually_ThenCombinedArrayHoldsFirstThenSecond()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingNewArrayManually(first, second);

            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
            Assert.Equal(_expectedMerged, combinedArray);
        }
    }
}
