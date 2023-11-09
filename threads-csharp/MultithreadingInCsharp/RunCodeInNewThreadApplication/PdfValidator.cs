using System;
using System.Threading;

namespace RunCodeInNewThreadApplication
{
    public class PdfValidator
    {
        internal int DelaySeconds { get; set; } = 5;
        public ValidationResult ValidateFile()
        {
            //let's pretend this is a long, CPU-intensive work.
            Thread.Sleep(TimeSpan.FromSeconds(DelaySeconds));
            return new ValidationResult();
        }
    }

    public class ValidationResult
    {
        public string ResultCode { get; } = Guid.NewGuid().ToString();
    }
}