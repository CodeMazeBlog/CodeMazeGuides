using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesTest
{
    public class ActionDelegateTest
    {
        private readonly ActionDelegateInCSharp sut;
        public ActionDelegateTest()
        {
            sut = new();
        }

        [Fact]
        public void ExecuteWithoutParameter_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameter();

            var output = sw.ToString();
            Assert.Equal("Code Maze\r\n", output);
        }

        [Fact]
        public void ExecuteWithParameter_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithParameter();

            var output = sw.ToString();
            Assert.Equal("Code Maze from Parameters\r\n", output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingAnonymousMethod_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameterUsingAnonymousMethod();

            var output = sw.ToString();
            Assert.Equal("Code Maze\r\n", output);
        }

        [Fact]
        public void ExecuteWithParameterUsingAnonymousMethod_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithParameterUsingAnonymousMethod();

            var output = sw.ToString();
            Assert.Equal("Code Maze from Parameters using Anonymous Method\r\n", output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingLambdaExpressions_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithoutParameterUsingLambdaExpressions();

            var output = sw.ToString();
            Assert.Equal("Code Maze\r\n", output);
        }

        [Fact]
        public void ExecuteWithParameterUsingLambdaExpressions_ShouldPrintToConsole()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            sut.ExecuteWithParameterUsingLambdaExpressions();

            var output = sw.ToString();
            Assert.Equal("Code Maze from Parameters using Lambda Expressions\r\n", output);
        }
    }
}
