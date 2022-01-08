using System;
using System.Diagnostics;
using NUnit.Framework;
using RunCodeInNewThreadConsoleApplication;

namespace RunCodeInNewThreadApplicationTests
{
    public class PdfValidatorTests
    {
        [Test]
        public void ValidateFile_RunsWithADelay()
        {
            var validator = new PdfValidator(1);
            validator.Delay = 2;
            Stopwatch sw = Stopwatch.StartNew();

            validator.ValidateFile();

            Assert.IsTrue(sw.ElapsedMilliseconds >= 2000);
        }

        [Test]
        public void ValidateFile_DefaultDelayIsNoticeableByHuman()
        {
            var validator = new PdfValidator(1);
            Assert.IsTrue(validator.Delay >= 1);
        }

      
    }
}