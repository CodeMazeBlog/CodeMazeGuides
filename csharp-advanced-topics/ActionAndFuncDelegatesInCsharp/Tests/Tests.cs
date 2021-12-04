using System;
using Xunit;
using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void FuncDelegateTest()
        {
            Assert.Equal(80 , Program.FuncDelegate());
         
            Assert.Equal(50, Program.FuncDelegateByAnonymous());
            
            Assert.Equal(40, Program.FuncDelegateByLambdaExpression());
        }

        [Fact]
        public void ActionDelegatesTest()
        {
            Assert.Equal(1,Program.ActionDelegate());
            Assert.Equal(1,Program.ActionDelegateByAnonymous());
            Assert.Equal(1,Program.ActionDelegateByLambdaExpression());
        }
    }
}
