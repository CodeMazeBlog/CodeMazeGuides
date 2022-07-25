using System;
using System.IO;
using Xunit;

namespace ActionAndFuncDelegatesInCsharpTests
{
    public class ActionAndFuncDelegateTests : IDisposable
    {
        private readonly TextWriter _originalConsoleOut;
        private readonly StringWriter _fakeConsoleOut;

        private readonly string _expectedHelloWorldOutput = $"Hello World!{Environment.NewLine}";

        public ActionAndFuncDelegateTests()
        {
            _originalConsoleOut = Console.Out;
            _fakeConsoleOut = new StringWriter();
            Console.SetOut(_fakeConsoleOut);
        }

        public void Dispose()
        {
            Console.SetOut(_originalConsoleOut);
            _fakeConsoleOut.Dispose();
        }

        [Fact]
        public void WhenActionInstanceIsExecuted_ThenConsoleOutputsHelloWorld()
        {
            DemoClass.RunActionWithInstantiation();
            Assert.Equal(_expectedHelloWorldOutput, _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenReferenceActionIsExecuted_ThenConsoleOutputsHelloWorld()
        {
            DemoClass.RunActionWithReference();
            Assert.Equal(_expectedHelloWorldOutput, _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenLambdaActionIsExecuted_ThenConsoleOutputsHelloWorld()
        {
            DemoClass.RunActionWithLambdaMethod();
            Assert.Equal(_expectedHelloWorldOutput, _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenHigherOrderActionIsExecuted_ThenConsoleOutputsGreetingsHelloWorld()
        {
            DemoClass.RunActionInHigherOrderFunction();
            Assert.Equal($"Greetings! {_expectedHelloWorldOutput}", _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenActionWithAParameterIsExecuted_ThenConsoleOutputsHelloCodeMaze()
        {
            DemoClass.RunActionWithAParameter();
            Assert.Equal($"Hello Code Maze!{Environment.NewLine}", _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenFuncWithoutParameterIsExecuted_ThenConsoleOutputs42()
        {
            DemoClass.RunFuncWithoutParameter();
            Assert.Equal($"42{Environment.NewLine}", _fakeConsoleOut.ToString());
        }

        [Fact]
        public void WhenFuncWithAParameterIsExecuted_ThenConsoleOutputs47()
        {
            DemoClass.RunFuncWithAParameter();
            Assert.Equal($"47{Environment.NewLine}", _fakeConsoleOut.ToString());
        }
    }
}