namespace ActionAndFuncDelegateInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<object> businessobj = new();

            ReportManager<object> reportManager = new();
            var report1 = reportManager.GetReport(businessobj);
            Console.WriteLine(report1);

            ReportManager<object> reportManager2 = new(ReportFormatPlugins<object>.PDFReportWriter);
            var report2 = reportManager2.GetReport(businessobj);
            Console.WriteLine(report2);

            ReportManager<object> reportManager3 = new(ReportFormatPlugins<object>.XLSXReportWriter);
            var report3 = reportManager3.GetReport(businessobj);
            Console.WriteLine(report3);
        }

    }
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
    public class ReportManager<T> where T : class
    {
        private Func<List<T>, string> WriteToFileInCustomFormat { get; set; }

        Action delegate1 = new Action(() => { });
        Action<int> delegate2 = new((param1) => { });
        Action<int, int> delegate3 = new((param1, param2) => { });
        Action<int, int, int> delegate4 = new((param1, param2, param3) => { });

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

