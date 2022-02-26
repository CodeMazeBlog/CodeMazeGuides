using Xunit;
using ActionFuncDelegate;

namespace ActionFuncDelegateTest 
{
    public class ActionDelegateTest
    {
        [Fact]
        public void GivenTwoValues_ThenCalculateSum()
        {
            var valA = 120;
            var valB = 160;
            var expectedSum = valA + valB;

            ActionDelegate.Add(valA, valB);
            Assert.Equal(expectedSum, ActionDelegate.Sum);
        }
    }
}
