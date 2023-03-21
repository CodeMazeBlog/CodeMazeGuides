using ActionFuncInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class ActionUnitTests
    {
        private readonly int[] _array;
        private readonly int[] _emptyArray;

        public ActionUnitTests()
        {
            _array = new int[] { 5, 5, 5 };
            _emptyArray = new int[] { };
        }

        [Fact]
        public void WhenArrayPassedToSum_ThenSuccessful()
        {
            var expectedResult = 15;

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.PrintSum(_array);

            Assert.Equal(expectedResult, demonstrateAction.Sum);
        }

        [Fact]
        public void WhenNoArrayPassedToSum_ThenFail()
        {
            var expectedResult = 0;

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.PrintSum(_emptyArray);

            Assert.Equal(expectedResult, demonstrateAction.Sum);
        }

        [Fact]
        public void WhenArrayPassedToProduct_ThenSuccessful()
        {
            var expectedResult = 125;

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.PrintProduct(_array);

            Assert.Equal(expectedResult, demonstrateAction.Product);
        }

        [Fact]
        public void WhenNoArrayPassedToProduct_ThenFail()
        {
            var expectedResult = "InvalidOperationException";

            try
            {

                DemonstrateAction demonstrateAction = new();
                demonstrateAction.PrintProduct(_emptyArray);
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

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.Common(demonstrateAction.PrintSum, _array);
            Assert.Equal(expectedResult, demonstrateAction.Sum);
        }

        [Fact]
        public void WhenSumPassedAndNoArrayPassedToCommon_ThenFail()
        {
            var expectedResult = 0;

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.Common(demonstrateAction.PrintSum, _emptyArray);
            Assert.Equal(expectedResult, demonstrateAction.Sum);
        }

        [Fact]
        public void WhenProductPassedToCommon_ThenSuccessful()
        {
            var expectedResult = 125;

            DemonstrateAction demonstrateAction = new();
            demonstrateAction.Common(demonstrateAction.PrintProduct, _array);
            Assert.Equal(expectedResult, demonstrateAction.Product);
        }

        [Fact]
        public void WhenProductPassedAndNoArrayPassedToCommon_ThenFail()
        {
            var expectedResult = "InvalidOperationException";

            try
            {
                DemonstrateAction demonstrateAction = new();
                demonstrateAction.Common(demonstrateAction.PrintProduct, _emptyArray);
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
                DemonstrateAction demonstrateAction = new();
                demonstrateAction.Common(null, _array);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }
    }
}
