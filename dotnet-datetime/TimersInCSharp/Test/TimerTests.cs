using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;

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

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnEventExecution;
            timer.Start();

            Thread.Sleep(3000);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count >= 1);
        }

        public void OnEventExecution(Object? source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Elapsed event at {e.SignalTime:G}");
        }

        [TestMethod]
        public void WhenTimerSetUp_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) =>
            {
                sw.WriteLine($"Elapsed event at {e.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(3000);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count > 1);
        }

        [TestMethod]
        public void WhenTimerSetUpWithAutoResetFalse_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new System.Timers.Timer(1000);
            timer.AutoReset = false;
            timer.Elapsed += (s, e) =>
            {
                sw.WriteLine($"Elapsed event at {e.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(3000);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count == 1);
        }

        [TestMethod]
        public void WhenTimerSetUpWithAsyncHandler_TimedEventFired()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += async (s, e) =>
            {
                await sw.WriteLineAsync($"Elapsed event at {e.SignalTime:G}");
            };

            timer.Start();

            Thread.Sleep(3000);
            Assert.IsTrue(regex.Matches(sw.ToString()).Count >= 1);
        }

        [TestMethod]
        public void WhenTimerHandlerCausesException_ExceptionIsNotThrown()
        {
            var regex = new Regex("Elapsed event at");
            var sw = new StringWriter();

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) =>
            {
                sw.WriteLine($"Elapsed event at {e.SignalTime:G}");
                throw new Exception();
            };

            timer.Start();
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void WhenStopWatchUsed_TimeMeasured()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread.Sleep(1000);

            stopwatch.Stop();
            
            Console.WriteLine($"Total milliseconds: {stopwatch.Elapsed.TotalMilliseconds:F4}");
            Console.WriteLine($"Total seconds: {stopwatch.Elapsed.TotalSeconds:F4}");
            Console.WriteLine($"Total minutes: {stopwatch.Elapsed.TotalMinutes:F4}");

            Assert.IsTrue(stopwatch.Elapsed.TotalMilliseconds > 0);
        }
    }
}