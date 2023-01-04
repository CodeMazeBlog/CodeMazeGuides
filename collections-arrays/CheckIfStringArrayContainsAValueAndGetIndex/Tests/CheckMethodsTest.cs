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
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayIndexOf_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayIndexOf();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayFindIndex();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithArrayCaseInsensitiveFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ArrayCaseInsensitiveFindIndex();

            Assert.Equal(841, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithForLoop_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ForLoop();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithForEachLoop_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ForEachLoop();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithListIndexOf_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ListIndexOf();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithListFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ListFindIndex();

            Assert.Equal(998, result);
        }

        [Fact]
        public void GivenAnArrayAndAValue_WhenCheckingWithListCaseInsensitiveFindIndex_ThenReturnsAnIntegerIndex()
        {
            var result = _checkMethods.ListCaseInsensitiveFindIndex();

            Assert.Equal(841, result);
        }
    }
}