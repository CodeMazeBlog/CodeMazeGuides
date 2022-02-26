using Xunit;
using ActionFuncDelegate;

namespace ActionFuncDelegateTest 
{
    public class FuncDelegateTest
    {
        [Fact]
        public void GivenRadiusValue_ThenReturnCorrectAreaOfCircle()
        {
            var radius = 2;
            var valueOfPi = 3.14;
            var exepectedRadius = valueOfPi * radius * radius;

            var returnedRadius = FuncDelegate.AreaOfCircle(radius);
            Assert.Equal(exepectedRadius, returnedRadius);
        }
    }
}
