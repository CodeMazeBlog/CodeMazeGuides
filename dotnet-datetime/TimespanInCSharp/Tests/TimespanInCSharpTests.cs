using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimespanInCSharp.Classes;
using static TimespanInCSharp.Classes.Variables;

namespace Tests
{
    [TestClass]
    public class TimespanInCSharpTests
    {
        [TestMethod]
        public void WhenHourMinuteSecondIsSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsHMS = initHelper.InitiateTimespan(2, 30, 5);
            Assert.AreEqual(tsHMS, TimeSpan.FromSeconds(2 * 60 * 60 + 30 * 60 + 5));
        }

        [TestMethod]
        public void WhenDayHourMinuteSecondIsSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsDHMS = initHelper.InitiateTimespan(1, 2, 30, 5);
            Assert.AreEqual(tsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5));
        }

        [TestMethod]
        public void WhenDayHourMinuteSecondMsIsSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsDHMS = initHelper.InitiateTimespan(1, 2, 30, 5, 2000);
            Assert.AreEqual(tsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5 + 2));
        }

        [TestMethod]
        public void WhenTicksIsSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsHMS = initHelper.InitiateTimespan(20000);
            Assert.AreEqual(tsHMS, TimeSpan.FromMilliseconds(2));
        }

        [TestMethod]
        public void WhenDaySent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsD = initHelper.InitiateTimespan(1, TimePart.Day);
            Assert.AreEqual(tsD, TimeSpan.FromHours(24));
        }

        [TestMethod]
        public void WhenHourSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsH = initHelper.InitiateTimespan(5, TimePart.Hour);
            Assert.AreEqual(tsH, TimeSpan.FromHours(5));
        }

        [TestMethod]
        public void WhenMinuteSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsH = initHelper.InitiateTimespan(30, TimePart.Minute);
            Assert.AreEqual(tsH, TimeSpan.FromMinutes(30));
        }

        [TestMethod]
        public void WhenSecSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsH = initHelper.InitiateTimespan(30, TimePart.Second);
            Assert.AreEqual(tsH, TimeSpan.FromSeconds(30));
        }

        [TestMethod]
        public void WhenMsSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsH = initHelper.InitiateTimespan(1000, TimePart.MilliSecond);
            Assert.AreEqual(tsH, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void WhenTicksSent_InitiateTimespan()
        {
            var initHelper = new InitiationHelper();
            TimeSpan tsM = initHelper.InitiateTimespan(1000 * 10000, TimePart.Ticks);
            Assert.AreEqual(tsM, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void WhenStringSent_Parse()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate("00:00:10", Operation.Parse);
            Assert.AreEqual(tsParse, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenStringSent_ParseExact()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate("00:10", Operation.ParseExact);
            Assert.AreEqual(tsParse, TimeSpan.FromMinutes(10));
        }

        [TestMethod]
        public void WhenStringSent_TryParse()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate("00:00:10", Operation.TryParse);
            Assert.AreEqual(tsParse, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenStringSent_TryParseExact()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate("00:10", Operation.TryParseExact);
            Assert.AreEqual(tsParse, TimeSpan.FromMinutes(10));
        }

        [TestMethod]
        public void WhenValuesSent_Add()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(45), Operation.Add);
            Assert.AreEqual(tsParse, TimeSpan.FromSeconds(90));
        }

        [TestMethod]
        public void WhenValuesSent_Substract()
        {
            var operateHelper = new OperationHelper();
            TimeSpan tsParse = operateHelper.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(30), Operation.Substract);
            Assert.AreEqual(tsParse, TimeSpan.FromSeconds(15));
        }

    }
}