using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Timers;
using Thread = System.Threading.Thread;

namespace Test
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        public void WhenTimerSetUpWithMethodHandler_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();
            Console.SetOut(sw);

            var timer = new Timer(100);
            timer.Elapsed += OnEventExecution;
            timer.Start();

            Thread.Sleep(300);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count >= 1);
        }

        public void OnEventExecution(Object? sender, ElapsedEventArgs eventArgs)
        {
            Console.WriteLine($"Elapsed event at {eventArgs.SignalTime:G}");
        }

        [TestMethod]
        public void WhenTimerSetUp_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new Timer(100);
            timer.Elapsed += (sender, eventArgs) =>
            {
                sw.WriteLine($"Elapsed event at {eventArgs.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(300);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count > 1);
        }

        [TestMethod]
        public void WhenTimerSetUpWithAutoResetFalse_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new Timer(100);
            timer.AutoReset = false;
            timer.Elapsed += (sender, eventArgs) =>
            {
                sw.WriteLine($"Elapsed event at {eventArgs.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(300);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count == 1);
        }

        [TestMethod]
        public void WhenTimerSetUpWithAsyncHandler_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new Timer(100);
            timer.Elapsed += async (sender, eventArgs) =>
            {
                await sw.WriteLineAsync($"Elapsed event at {eventArgs.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(300);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count >= 1);
        }

        [TestMethod]
        public void WhenTimerHandlerCausesException_ExceptionIsNotThrown()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new Timer(100);
            timer.Elapsed += (sender, eventArgs) =>
            {
                sw.WriteLine($"Elapsed event at {eventArgs.SignalTime:G}");
                throw new Exception();
            };

            timer.Start();
            Thread.Sleep(300);
        }

        [TestMethod]
        public void WhenStopWatchUsed_TimeMeasured()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread.Sleep(100);

            stopwatch.Stop();

            Console.WriteLine($"Total milliseconds: {stopwatch.Elapsed.TotalMilliseconds:F4}");
            Console.WriteLine($"Total seconds: {stopwatch.Elapsed.TotalSeconds:F4}");
            Console.WriteLine($"Total minutes: {stopwatch.Elapsed.TotalMinutes:F4}");

            Assert.IsTrue(stopwatch.Elapsed.TotalMilliseconds > 0);
        }
    }
}