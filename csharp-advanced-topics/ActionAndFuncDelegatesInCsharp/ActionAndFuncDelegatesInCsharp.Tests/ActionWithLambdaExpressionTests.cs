using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    [Collection("Sequential")]
    public class ActionWithLambdaExpressionTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ActionWithLambdaExpression actionWithLambdaExpression = new ActionWithLambdaExpression();
            actionWithLambdaExpression.RunExample();
            Assert.Equal("Hello" + Environment.NewLine, stringWriter.ToString());
        }

    }
}
