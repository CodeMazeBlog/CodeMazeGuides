using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    [Collection("Sequential")]
    public class ActionWithAnAnonymousMethodTests
    {
        [Fact]
        public void WhenCallingAnonymousMethodUsingAction_ThenPrintHello()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ActionWithAnAnonymousMethod actionWithAnAnonymousMethod = new ActionWithAnAnonymousMethod();
            actionWithAnAnonymousMethod.RunExample();

            Assert.Equal("Hello" + Environment.NewLine, stringWriter.ToString());
        }

    }
}
