using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesTest
{
    public  class FuncDelegateTest
    {
        private readonly FuncDelegateInCSharp sut;

        public FuncDelegateTest()
        {
            sut = new();
        }

        [Fact]
        public void ExecuteWithoutParameter_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameter();

            Assert.Equal("True\r\n", sw.ToString());
        }

        [Fact]
        public void ExecuteWithParameter_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithParameter();

            Assert.Equal("False\r\n", sw.ToString());
        }

        [Fact]
        public void ExecuteWithoutParameterUsingAnonymousMethod_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameterUsingAnonymousMethod();

            Assert.Equal("True\r\n", sw.ToString());
        }

        [Fact]
        public void ExecuteWithParameterUsingAnonymousMethod_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithParameterUsingAnonymousMethod();

            Assert.Equal("False\r\n", sw.ToString());
        }

        [Fact]
        public void ExecuteWithoutParameterUsingLambdaExpressions_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameterUsingLambdaExpressions();

            Assert.Equal("True\r\n", sw.ToString());
        }

        [Fact]
        public void ExecuteWithParameterUsingLambdaExpressions_ShouldPrintToConsole()
        {
            StringWriter sw = new();
            Console.SetOut(sw);

            sut.ExecuteWithParameterUsingLambdaExpressions();

            Assert.Equal("False\r\n", sw.ToString());
        }
    }
}
