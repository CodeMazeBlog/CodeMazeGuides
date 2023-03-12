using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegateInCSharp
{
    public static class ReportFormatPlugins<T> where T : class
    {
        public static string TextReportWriter(List<T> data)
        {
            return Path.ChangeExtension(Path.GetTempFileName(), "TXT");
        }

        public static string PDFReportWriter(List<T> data)
        {
            return Path.ChangeExtension(Path.GetTempFileName(), "PDF");
        }

        public static string XLSXReportWriter(List<T> data)
        {
            return Path.ChangeExtension(Path.GetTempFileName(), "XLSX");
        }
    }
}
