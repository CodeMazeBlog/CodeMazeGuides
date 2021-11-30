using System;
using System.Threading;

namespace RunCodeInNewThreadApplication
{
    public class PdfValidator
    {
        public ValidationResult ValidateFile()
        {
            //let's pretend this is a long, CPU-intensive work.
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return new ValidationResult();
        }
    }

    public class ValidationResult
    {
        public string ResultCode { get; } = Guid.NewGuid().ToString();
    }
}