using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegate.Test
{
    public class FuncSample_Test
    {
        [Fact]
        public void GivenTwoNumber_WhenOperationIsAdd_ThenNumbersAreAdded()
        {
            var res = FuncSample.Calculate(1, 2, "add");
            Assert.Equal(3, res);
        }

        [Fact]
        public void GivenTwoNumber_WhenOperationIsMultiply_ThenNumbersAreMultiplied()
        {
            var res = FuncSample.Calculate(1, 2, "multiply");
            Assert.Equal(2, res);
        }
    }
}
