using System;
using System.Threading;

namespace RunCodeInNewThreadConsoleApplication
{
    public class PdfValidator
    {
        private readonly int _instanceNumber;
        private static readonly Random _randomizer = new();

        public PdfValidator(int instanceNumber)
        {
            _instanceNumber = instanceNumber;
        }

        internal int Delay { get; set; } = _randomizer.Next(1, 5);
        public string ValidateFile()
        {
            Console.WriteLine($"{ThreadInfo.Log()} PDF Validation {_instanceNumber} starting.");
            //let's pretend this is a long, CPU-intensive work.
            Thread.Sleep(TimeSpan.FromSeconds(Delay));
            Console.WriteLine($"{ThreadInfo.Log()} PDF Validation {_instanceNumber} finishing after {Delay}s.");
            //let's get some random dummy result
            return $"File {_instanceNumber} valid: [{_randomizer.Next(0,2) == 1}]";
        }
    }
}