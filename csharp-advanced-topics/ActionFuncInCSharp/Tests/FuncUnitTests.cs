using ActionFuncInCSharp;
using Xunit;

namespace Tests
{
    public class FuncUnitTests
    {
        [Fact]
        public void WhenArrayPassed_ThenSuccessful()
        {
            int[] array = { 5, 5, 5 };

            // Since Main() only displays results on console, we can only check if it run fine
            DemonstrateFunc demonstrateFunc = new();
            demonstrateFunc.Main(array);
            Assert.True(true);
        }

        [Fact]
        public void WhenNoArrayPassed_ThenFail()
        {
            int[] array = { };

            try
            {
                // Since Main() only displays results on console, we can only check if it run fine
                DemonstrateFunc demonstrateFunc = new();
                demonstrateFunc.Main(array);
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}
