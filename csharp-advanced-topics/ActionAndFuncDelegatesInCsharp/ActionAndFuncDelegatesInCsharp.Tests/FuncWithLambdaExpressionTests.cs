using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    public class FuncWithLambdaExpressionTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            FuncWithLambdaExpression funcWithLambdaExpression = new FuncWithLambdaExpression();
            int result = funcWithLambdaExpression.RunExample();
            Assert.IsType<int>(result);
        }

    }
}
