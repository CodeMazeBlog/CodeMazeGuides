using System;
using System.IO;
using ActionAndFuncDelegates;
using Xunit;

namespace ActionAndFuncDelegatesTests
{
    public class ActionAndFuncTests : IDisposable
    {
        readonly StringWriter strOut = new();
        readonly string NewLine = Environment.NewLine;

        public ActionAndFuncTests()
        {
            Console.SetOut(strOut);
        }

        void ResetOut() => strOut.GetStringBuilder().Clear();

        [Fact]
        public void WhenMethodIsDelegatedAsAction_ThenVerifyThatOutputIsSameAsOriginal()
        {
            var messenger = new Messenger();
            messenger.RelayMessage("Line1");

            var originalOutput = strOut.ToString();
            Assert.Equal($"Line1{NewLine}", originalOutput);

            ResetOut();

            var relay = messenger.RelayMessage;
            relay("Line1");

            var delegatedOutput = strOut.ToString();
            Assert.Equal(originalOutput, delegatedOutput);
        }

        [Fact]
        public void WhenActionsAreCombined_ThenVerifyThatBothActionsAreInvoked()
        {
            Action<string> relay1 = (msg) => Console.WriteLine($"Relay1: {msg}");
            Action<string> relay2 = (msg) => Console.WriteLine($"Relay2: {msg}");

            var relay = relay1 + relay2;

            relay1("Welcome");
            var relay1Output = strOut.ToString();
            Assert.Equal($"Relay1: Welcome{NewLine}", relay1Output);

            ResetOut();

            relay2("Welcome");
            var relay2Output = strOut.ToString();
            Assert.Equal($"Relay2: Welcome{NewLine}", relay2Output);

            ResetOut();

            relay("Welcome");
            var relayOutput = strOut.ToString();
            Assert.Equal(relay1Output + relay2Output, relayOutput);
        }

        [Fact]
        public void WhenMethodIsDelegatedAsFunc_ThenVerifyThatReturnedResultIsSameAsOriginal()
        {
            var formatter = new StringFormatter();

            var inputStr = "C# Basics";
            var originalReturn = formatter.FormatStringAsUppercase(inputStr);

            Assert.Equal($"C# BASICS", originalReturn);

            var formatFunc = formatter.FormatStringAsUppercase;
            var delegatedReturn = formatFunc(inputStr);

            Assert.Equal(originalReturn, delegatedReturn);
        }

        [Theory]
        [InlineData(nameof(Demo.ExampleCallDirectMethod), $"Line1\r\nLine2\r\nLine3\r\n")]
        [InlineData(nameof(Demo.ExampleCallMethodByAction), $"Line1\r\nLine2\r\nLine3\r\n")]
        [InlineData(nameof(Demo.ExampleMultiParamMethodByAction), $"Demo [#1]: Line1\r\nDemo [#2]: Line2\r\nDemo [#3]: Line3\r\n")]
        [InlineData(nameof(Demo.ExampleMultiParamMethodByShortenedAction), $"Demo [#1]: Line1\r\nDemo [#2]: Line2\r\nDemo [#3]: Line3\r\n")]
        [InlineData(nameof(Demo.ExampleCombinedAction), $"Relay1: Welcome\r\nRelay2: Welcome\r\n")]
        [InlineData(nameof(Demo.ExamplePassActionAsMethodParameter), $"Line1\r\nLine2\r\nLine3\r\n")]
        [InlineData(nameof(Demo.ExampleResultOfMethodByFunc), $"C# BASICS\r\n20211227\r\n")]
        [InlineData(nameof(Demo.ExampleFuncUsingInlineLambdaSyntax), $"True\r\nFalse\r\n")]
        [InlineData(nameof(Demo.ExamplePassFuncAsMethodParameter), $"C# BASICS\r\nC# DELEGATES\r\nACTIONS AND FUNCS\r\n")]
        public void VerifyDemoExamples(string methodName, string expectedOutput)
        {
            typeof(Demo).GetMethod(methodName)?.Invoke(null, null);

            var actualOutput = strOut.ToString();
            Assert.Equal(expectedOutput.Replace("\r\n", NewLine), actualOutput);
        }

        public void Dispose()
        {
            strOut.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}