using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    [Collection("Sequential")]
    public class CallingAMethodWithActionTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            CallingAMethodWithAction callingAMethodWithAction = new CallingAMethodWithAction();
            callingAMethodWithAction.RunExample();
            Assert.Equal("Hi" + Environment.NewLine, stringWriter.ToString());
        }
    }
}
