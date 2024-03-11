using ActionAndFuncDelegatesInCSharp.Common;

namespace ActionAndFuncDelegatesInCSharp.Tests
{
    public class DelegateTests
    {
        [Fact]
        public void GetTaxAmountTest()
        {
            var tax = DelegateHelper.GetTax(100000);
            Assert.Equal(100000 * .3, tax);
        }
    }
}