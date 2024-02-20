using ActionAndFuncDelegates;

namespace Tests
{
    public class ActionFuncDelegateUnitTest
    {
        [Fact]
        public void WhenNumberIsGiven_ThenCountDownToOne()
        {
            var number = "";

            foreach (var item in CallbackController.CountDown(10, CallbackController.CalculateMinusOne))
            {
                number = item;
            }

            Assert.Equal( "1", number);
        }

        [Fact]
        public async void WhenNumberIsGiven_ThenMultiplyItByTwo()
        {
            Func<int, Task<int>> asyncFunc = AsyncController.DoubleAsync;
            var result = await asyncFunc(5);

            Assert.Equal(5 * 2, result);
        }

    }
}
