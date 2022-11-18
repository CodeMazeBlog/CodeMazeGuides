using ActionAndFuncDelegates;

namespace Tests
{
    
    public class ActionAndFuncTest
    {
        static readonly Calculator calc = new();
        
        [Fact]
        public void GivenResult_WhenExecuted_ReturnsAnInteger()
        {
            var result = calc.Result();
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GivenExponent_WhenExecuted_ReturnAnInteger()
        {
            var result = calc.Exponent(7);
            Assert.IsType<int>(result);
        }
    }
}