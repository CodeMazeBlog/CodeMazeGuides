using HowToMergeArrays;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly MergeArrayBenchmark _mergeArrayRunner;
        private readonly int _combinedExpectedSize;
        private readonly int _combinedExpectedSizeDistinct = 2;

        public Tests()
        {
            _mergeArrayRunner = new MergeArrayBenchmark();
            _combinedExpectedSize = _mergeArrayRunner.ArraySize * 2;
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndNewArray_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithNewArray();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithArrayCopyAndResize_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyWithResize();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithArrayCopyTo_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingArrayCopyTo();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqConcat_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqConcat();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqUnion_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSizeDistinct()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqUnion();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSizeDistinct, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithLinqSelectMany_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingLinqSelectMany();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithBlockCopy_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingBlockCopy();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }

        [Fact]
        public void WhenMergingWithNewArrayManually_ThenCombinedArrayNotEmptyAndLengthEqualsDoubleSize()
        {
            var combinedArray = _mergeArrayRunner.MergeUsingNewArrayManually();

            Assert.NotEmpty(combinedArray);
            Assert.Equal(_combinedExpectedSize, combinedArray.Length);
        }
    }
}
