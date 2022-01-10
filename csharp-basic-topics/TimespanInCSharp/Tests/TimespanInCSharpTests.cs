using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application;

namespace Tests
{
    [TestClass]
    public class TimespanInCSharpTests
    {
		[TestMethod]
		public void WhenHourMinuteSecondIsSent_InitiateTimespan()
		{
			TimeSpan TsHMS = Program.InitiateTimespan(2,30,5);
			Assert.AreEqual(TsHMS, TimeSpan.FromSeconds(2*60*60 + 30*60 + 5));
		}
		[TestMethod]
		public void WhenDayHourMinuteSecondIsSent_InitiateTimespan()
		{
			TimeSpan TsDHMS = Program.InitiateTimespan(1, 2, 30, 5);
			Assert.AreEqual(TsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5));
		}
		[TestMethod]
		public void WhenDayHourMinuteSecondMsIsSent_InitiateTimespan()
		{
			TimeSpan TsDHMS = Program.InitiateTimespan(1, 2, 30, 5, 2000);
			Assert.AreEqual(TsDHMS, TimeSpan.FromSeconds(24 * 60 * 60 + 2 * 60 * 60 + 30 * 60 + 5 + 2));
		}
		[TestMethod]
		public void WhenTicksIsSent_InitiateTimespan()
		{
			TimeSpan TsHMS = Program.InitiateTimespan(20000);
			Assert.AreEqual(TsHMS, TimeSpan.FromMilliseconds(2));
		}
		[TestMethod]
		public void WhenDaySent_InitiateTimespan()
		{
			TimeSpan TsD = Program.InitiateTimespan(1, Program.TimePart.Day);
			Assert.AreEqual(TsD, TimeSpan.FromHours(24));
		}
		[TestMethod]
		public void WhenHourSent_InitiateTimespan()
		{
			TimeSpan TsH = Program.InitiateTimespan(5, Program.TimePart.Hour);
			Assert.AreEqual(TsH, TimeSpan.FromHours(5));
		}
		[TestMethod]
		public void WhenMinuteSent_InitiateTimespan()
		{
			TimeSpan TsH = Program.InitiateTimespan(30, Program.TimePart.Minute);
			Assert.AreEqual(TsH, TimeSpan.FromMinutes(30));
		}
		[TestMethod]
		public void WhenSecSent_InitiateTimespan()
		{
			TimeSpan TsH = Program.InitiateTimespan(30, Program.TimePart.Second);
			Assert.AreEqual(TsH, TimeSpan.FromSeconds(30));
		}
		[TestMethod]
		public void WhenMsSent_InitiateTimespan()
		{
			TimeSpan TsH = Program.InitiateTimespan(1000, Program.TimePart.MilliSecond);
			Assert.AreEqual(TsH, TimeSpan.FromSeconds(1));
		}
		[TestMethod]
		public void WhenTicksSent_InitiateTimespan()
		{
			TimeSpan TsM = Program.InitiateTimespan(1000*10000, Program.TimePart.Ticks);
			Assert.AreEqual(TsM, TimeSpan.FromSeconds(1));
		}
		[TestMethod]
		public void WhenStringSent_Parse()
		{
			TimeSpan TsParse = Program.Operate("00:00:10",Program.Operation.Parse);
			Assert.AreEqual(TsParse, TimeSpan.FromSeconds(10));
		}
		[TestMethod]
		public void WhenStringSent_ParseExact()
		{
			TimeSpan TsParse = Program.Operate("00:10", Program.Operation.ParseExact);
			Assert.AreEqual(TsParse, TimeSpan.FromMinutes(10));
		}
		[TestMethod]
		public void WhenStringSent_TryParse()
		{
			TimeSpan TsParse = Program.Operate("00:00:10", Program.Operation.TryParse);
			Assert.AreEqual(TsParse, TimeSpan.FromSeconds(10));
		}
		[TestMethod]
		public void WhenStringSent_TryParseExact()
		{
			TimeSpan TsParse = Program.Operate("00:10", Program.Operation.TryParseExact);
			Assert.AreEqual(TsParse, TimeSpan.FromMinutes(10));
		}
		[TestMethod]
		public void WhenValuesSent_Add()
		{
			TimeSpan TsParse = Program.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(45), Program.Operation.Add);
			Assert.AreEqual(TsParse, TimeSpan.FromMinutes(1.5));
		}
		[TestMethod]
		public void WhenValuesSent_Substract()
		{
			TimeSpan TsParse = Program.Operate(TimeSpan.FromSeconds(45), TimeSpan.FromSeconds(30), Program.Operation.Substract);
			Assert.AreEqual(TsParse, TimeSpan.FromSeconds(15));
		}
	}
}