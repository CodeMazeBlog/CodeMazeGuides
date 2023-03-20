using ActionFuncInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class FuncUnitTests
    {
        private readonly int[] _array;
        private readonly int[] _emptyArray;

        public FuncUnitTests()
        {
            _array = new int[] { 5, 5, 5 };
            _emptyArray = new int[] { };
        }

        [Fact]
        public void WhenArrayPassedToSum_ThenSuccessful()
        {
            var expectedResult = 15;

            DemonstrateFunc demonstrateFunc = new();
            var result = demonstrateFunc.Sum(_array);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WhenNoArrayPassedToSum_ThenFail()
        {

            var expectedResult = 0;

            DemonstrateFunc demonstrateFunc = new();
            var result = demonstrateFunc.Sum(_emptyArray);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WhenArrayPassedToProduct_ThenSuccessful()
        {
            var expectedResult = 125;

            DemonstrateFunc demonstrateFunc = new();
            var result = demonstrateFunc.Product(_array);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void WhenNoArrayPassedToProduct_ThenFail()
        {
            var expectedResult = "InvalidOperationException";

            try
            {

                DemonstrateFunc demonstrateFunc = new();
                var result = demonstrateFunc.Product(_emptyArray);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }

        [Fact]
        public void WhenSumPassedToCommon_ThenSuccessful()
        {
            var expectedResult = 15;

            DemonstrateFunc demonstrateFunc = new();
            demonstrateFunc.Common(demonstrateFunc.Sum, _array);
            Assert.Equal(expectedResult, demonstrateFunc.Result);
        }

        [Fact]
        public void WhenSumPassedAndNoArrayPassedToCommon_ThenFail()
        {
            var expectedResult = 0;

            DemonstrateFunc demonstrateFunc = new();
            demonstrateFunc.Common(demonstrateFunc.Sum, _emptyArray);
            Assert.Equal(expectedResult, demonstrateFunc.Result);
        }

        [Fact]
        public void WhenProductPassedToCommon_ThenSuccessful()
        {
            var expectedResult = 125;

            DemonstrateFunc demonstrateFunc = new();
            demonstrateFunc.Common(demonstrateFunc.Product, _array);
            Assert.Equal(expectedResult, demonstrateFunc.Result);
        }

        [Fact]
        public void WhenProductPassedAndNoArrayPassedToCommon_ThenFail()
        {
            var expectedResult = "InvalidOperationException";

            try
            {
                DemonstrateFunc demonstrateFunc = new();
                demonstrateFunc.Common(demonstrateFunc.Product, _emptyArray);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }

        [Fact]
        public void WhenNullPassedToCommon_ThenFail()
        {
            var expectedResult = "NullReferenceException";
            try
            {
                DemonstrateFunc demonstrateFunc = new();
                demonstrateFunc.Common(null, _array);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }
    }
}
