using System;
using System.Diagnostics;
using NUnit.Framework;
using RunCodeInNewThreadApplication;

namespace RunCodeInNewThreadApplicationTests
{
    public class PdfValidatorTests
    {
        [Test]
        public void ValidateFile_RunsWithADelay()
        {
            var validator = new PdfValidator();
            validator.DelaySeconds = 1;
            Stopwatch sw = Stopwatch.StartNew();

            validator.ValidateFile();

            Assert.IsTrue(sw.ElapsedMilliseconds >= 1000);
        }

        [Test]
        public void ValidateFile_DefaultDelayIsNoticeableByHuman()
        {
            var validator = new PdfValidator();
            Assert.IsTrue(validator.DelaySeconds > 2);
        }

        [Test]
        public void ValidateFile_ReturnsAGuid()
        {
            var validator = new PdfValidator();
            validator.DelaySeconds = 0;

            var result = validator.ValidateFile();

            Assert.DoesNotThrow(()=>Guid.Parse(result.ResultCode));
        }
    }
}