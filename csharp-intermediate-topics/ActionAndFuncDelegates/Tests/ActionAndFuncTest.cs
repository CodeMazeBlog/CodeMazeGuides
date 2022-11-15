using ActionAndFuncDelegates;

namespace Tests
{
    
    public class ActionAndFuncTest
    {
        static readonly Calculator calc = new();
        [Fact]
        public void GivenResultDelegate_WhenExecuted_ReturnsTheSameValueAsResult()
        {
            Func<int> resultDelegate = calc.Result;
            var result = calc.Result();
            var delegateResult = resultDelegate();
            Assert.Equal(result, delegateResult);
            
        }
        [Fact]
        public void GivenExponentDelegate_WhenExecuted_ReturnsTheSameValueAsExponent()
        {
            Func<int, int> exponentDelegate = calc.Exponent;
            var result = calc.Exponent(7);
            var delegateResult = exponentDelegate(7);
            Assert.Equal(result, delegateResult);
        }


    }
}