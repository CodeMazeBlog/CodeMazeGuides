using FuncAndActionDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharpTests
{
    public class DelegatesTests
    {
        [Fact]
        public void whenFirstOperationCalled_AllOperationWillExecute()
        {
            string u = string.Empty;
            var stateResult = ContinueExecutionUsingFunc.Operation1(u);
            var result = stateResult.result;

            Assert.Equal($"{nameof(ContinueExecutionUsingFunc.Operation1)}_{nameof(ContinueExecutionUsingFunc.Operation2)}_{nameof(ContinueExecutionUsingFunc.Operation3)}_{nameof(ContinueExecutionUsingFunc.Operation4)}", result);
        }

        [Fact]
        public void whenThirdOperationCalled_AllFollowedOperationWillExcute()
        {
            string u = string.Empty;
            var stateResult = ContinueExecutionUsingFunc.Operation3(u);
            var result = stateResult.result;

            Assert.Equal($"{nameof(ContinueExecutionUsingFunc.Operation3)}_{nameof(ContinueExecutionUsingFunc.Operation4)}", result);
        }
    }
}
