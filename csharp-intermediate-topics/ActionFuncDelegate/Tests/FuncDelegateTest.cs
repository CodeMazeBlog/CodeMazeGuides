using Xunit;
using ActionFuncDelegate;

namespace ActionFuncDelegateTest {

    public class FuncDelegateTest
    {
        [Fact]
        public void GivenRadiusValue_ThenReturnCorrectAreaOfCircle()
        {
            int radius = 2;
            double valueOfPi = 3.14;
            double exepectedRadius = valueOfPi * radius * radius;

            double returnedRadius = FuncDelegate.AreaOfCircle(radius);
            Assert.Equal(exepectedRadius, returnedRadius);
        }
    }
}
