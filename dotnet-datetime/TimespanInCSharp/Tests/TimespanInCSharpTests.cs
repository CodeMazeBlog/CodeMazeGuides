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
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsHMS = initHelper.InitiateTimespan(2, 30, 5);
            Assert.AreEqual(TsHMS, TimeSpan.FromSeconds(2 * 60 * 60 + 30 * 60 + 5));
        }

        [TestMethod]
        public void WhenDayHourMinuteSecondIsSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsDHMS = initHelper.InitiateTimespan(1, 2, 30, 5);
            Assert.AreEqual(TsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5));
        }

        [TestMethod]
        public void WhenDayHourMinuteSecondMsIsSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsDHMS = initHelper.InitiateTimespan(1, 2, 30, 5, 2000);
            Assert.AreEqual(TsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5 + 2));
        }

        [TestMethod]
        public void WhenTicksIsSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsHMS = initHelper.InitiateTimespan(20000);
            Assert.AreEqual(TsHMS, TimeSpan.FromMilliseconds(2));
        }

        [TestMethod]
        public void WhenDaySent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsD = initHelper.InitiateTimespan(1, TimePart.Day);
            Assert.AreEqual(TsD, TimeSpan.FromHours(24));
        }

        [TestMethod]
        public void WhenHourSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsH = initHelper.InitiateTimespan(5, TimePart.Hour);
            Assert.AreEqual(TsH, TimeSpan.FromHours(5));
        }

        [TestMethod]
        public void WhenMinuteSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsH = initHelper.InitiateTimespan(30, TimePart.Minute);
            Assert.AreEqual(TsH, TimeSpan.FromMinutes(30));
        }

        [TestMethod]
        public void WhenSecSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsH = initHelper.InitiateTimespan(30, TimePart.Second);
            Assert.AreEqual(TsH, TimeSpan.FromSeconds(30));
        }

        [TestMethod]
        public void WhenMsSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsH = initHelper.InitiateTimespan(1000, TimePart.MilliSecond);
            Assert.AreEqual(TsH, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void WhenTicksSent_InitiateTimespan()
        {
            InitiationHelper initHelper = new InitiationHelper();
            TimeSpan TsM = initHelper.InitiateTimespan(1000 * 10000, TimePart.Ticks);
            Assert.AreEqual(TsM, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void WhenStringSent_Parse()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate("00:00:10",Operation.Parse);
            Assert.AreEqual(TsParse, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenStringSent_ParseExact()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate("00:10", Operation.ParseExact);
            Assert.AreEqual(TsParse, TimeSpan.FromMinutes(10));
        }

        [TestMethod]
        public void WhenStringSent_TryParse()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate("00:00:10", Operation.TryParse);
            Assert.AreEqual(TsParse, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void WhenStringSent_TryParseExact()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate("00:10", Operation.TryParseExact);
            Assert.AreEqual(TsParse, TimeSpan.FromMinutes(10));
        }

        [TestMethod]
        public void WhenValuesSent_Add()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(45), Operation.Add);
            Assert.AreEqual(TsParse, TimeSpan.FromSeconds(90));
        }

        [TestMethod]
        public void WhenValuesSent_Substract()
        {
            OperationHelper operateHelper = new OperationHelper();
            TimeSpan TsParse = operateHelper.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(30), Operation.Substract);
            Assert.AreEqual(TsParse, TimeSpan.FromSeconds(15));
        }
        

    }
}