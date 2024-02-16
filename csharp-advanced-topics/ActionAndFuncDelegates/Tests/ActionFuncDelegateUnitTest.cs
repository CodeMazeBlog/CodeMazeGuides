using ActionAndFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Assert.Equal(number, "1");
        }

        [Fact]
        public async void WhenNumberIsGiven_MultiplyItByTwo()
        {
            Func<int, Task<int>> asyncFunc = AsyncController.DoubleAsync;
            int result = await asyncFunc(5);

            Assert.Equal(5 * 2, result);
        }

    }
}
