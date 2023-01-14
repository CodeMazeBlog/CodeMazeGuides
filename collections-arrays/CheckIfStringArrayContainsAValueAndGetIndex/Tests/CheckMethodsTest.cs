using CheckIfStringArrayContainsAValueAndGetIndex;

namespace Tests
{
    public class CheckMethodsTest
    {
        private readonly CheckMethods _checkMethods;
        public CheckMethodsTest()
        {
            _checkMethods = new CheckMethods();
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithForLoop_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ForLoop();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithForEachLoop_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ForEachLoop();

            Assert.Equal(0, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayIndexOf_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayIndexOf();

            Assert.Equal(3, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndex();

            Assert.Equal(5, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayCaseInsensitiveFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayCaseInsensitiveFindIndex();

            Assert.Equal(6, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndexWithContains_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndexWithContains();

            Assert.Equal(4, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndexWithStartsWith_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndexWithStartsWith();

            Assert.Equal(3, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndexWithEndsWith_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndexWithEndsWith();

            Assert.Equal(1, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndexWithRegex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndexWithRegex();

            Assert.Equal(5, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayLastIndexOf_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayLastIndexOf();

            Assert.Equal(8, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindLastIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindLastIndex();

            Assert.Equal(7, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayCaseInsensitiveFindLastIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayCaseInsensitiveFindLastIndex();

            Assert.Equal(9, result);
        }
    }
}