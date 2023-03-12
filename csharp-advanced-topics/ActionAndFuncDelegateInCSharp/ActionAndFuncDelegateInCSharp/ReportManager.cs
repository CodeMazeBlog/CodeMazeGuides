using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegateInCSharp
{
    public class ReportManager<T> where T : class
    {
        private Func<List<T>, string> WriteToFileInCustomFormat { get; set; }

        public ReportManager()
        {
            WriteToFileInCustomFormat = ReportFormatPlugins<T>.TextReportWriter;
        }

        public ReportManager(Func<List<T>, string> reportformat)
        {
            WriteToFileInCustomFormat = reportformat;
        }

        public string GetReport(List<T> businessobj)
        {
            return WriteToFileInCustomFormat.Invoke(businessobj);
        }
    }
}
