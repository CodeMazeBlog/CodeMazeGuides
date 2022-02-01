using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    [Collection("Sequential")]
    public class PassingParameterToAMethodUsingActionTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            PassingParameterToAMethodUsingAction passingParameterToAMethodUsingAction = new PassingParameterToAMethodUsingAction();
            passingParameterToAMethodUsingAction.RunExample();
            Assert.Equal("A message." + Environment.NewLine, stringWriter.ToString());
        }
    }
}
