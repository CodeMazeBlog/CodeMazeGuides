using System;
using System.IO;
using CodeMaze;
using Xunit;

namespace ActionAndFuncDelegatesTests
{
    public class ActionAndFuncTests : IDisposable
    {
        readonly StringWriter strOut = new StringWriter();
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

            var greetings = "Welcome to CodeMaze";
            messenger.MessageRelayMethod(greetings);

            var originalOutput = strOut.ToString();
            Assert.Equal($"{greetings}{NewLine}", originalOutput);

            ResetOut();

            var relayAction = messenger.MessageRelayMethod;
            relayAction(greetings);

            var delegatedOutput = strOut.ToString();
            Assert.Equal(originalOutput, delegatedOutput);
        }

        [Fact]
        public void WhenActionsAreCombined_ThenVerifyThatBothActionsAreInvoked()
        {
            var messenger = new Messenger();

            var greetings = "Welcome to CodeMaze";
            var action1 = messenger.MessageRelayMethod;
            Action<string> action2 = (m) => messenger.AnotherMessageRelayMethod("TEST", m);

            action1(greetings);
            var action1Output = strOut.ToString();
            Assert.Equal($"{greetings}{NewLine}", action1Output);

            ResetOut();

            action2(greetings);
            var action2Output = strOut.ToString();
            Assert.Equal($"TEST: {greetings}{NewLine}", action2Output);

            ResetOut();

            var mergedAction = action1 + action2;
            mergedAction(greetings);
            var mergedActionOutput = strOut.ToString();
            Assert.Equal(action1Output + action2Output, mergedActionOutput);
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

        public void Dispose()
        {
            strOut.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}