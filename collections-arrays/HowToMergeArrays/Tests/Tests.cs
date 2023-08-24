using HowToMergeArrays;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly MergeArrayBenchmark _mergeArrayRunner;
        private readonly int _combinedExpectedSize;
        private readonly int _combinedExpectedSizeDistinct = 2;

        private readonly int[] first;
        private readonly int[] second;

        public Tests()
        {
            _mergeArrayRunner = new MergeArrayBenchmark();
            _combinedExpectedSize = _mergeArrayRunner.ArraySize * 2;
            first = Enumerable.Repeat(1, _mergeArrayRunner.ArraySize).ToArray();
            second =Enumerable.Repeat(2, _mergeArrayRunner.ArraySize).ToArray();
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndNewArray_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithNewArray(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndResize_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithResize(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithArrayCopyTo_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyTo(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqConcat_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqConcat(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqUnion_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSizeDistinct()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqUnion(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSizeDistinct, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqSelectMany_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqSelectMany(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithBlockCopy_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingBlockCopy(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithNewArrayManually_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingNewArrayManually(first, second);

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }
    }
}
