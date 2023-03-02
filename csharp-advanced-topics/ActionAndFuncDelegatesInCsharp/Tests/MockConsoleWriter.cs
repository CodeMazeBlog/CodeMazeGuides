using ActionAndFuncDelegatesInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MockConsoleWriter : IConsoleWriter
    {
        private StringBuilder _output = new StringBuilder();
        public void WriteLine(string? value)
        {
            _output.AppendLine(value+";");
        }
        public void VerifyOutput(string input,int times)
        {
            if (times ==1 ) {
                _output.ToString().Split(';').Where(p => p == input).Single();
            }
            else
            {
                if (_output.ToString().Split(';').Where(p => p == input).Count() != times)
                    throw new Exception();
            }
        }
    }
}
