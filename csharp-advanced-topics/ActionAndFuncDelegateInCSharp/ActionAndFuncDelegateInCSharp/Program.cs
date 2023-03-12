namespace ActionAndFuncDelegateInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<object> businessobj = new();

            ReportManager<object> reportManagerCsv = new();
            var csvReport = reportManagerCsv.GetReport(businessobj);
            Console.WriteLine(csvReport);

            ReportManager<object> reportManagerPdf = new(ReportFormatPlugins<object>.PDFReportWriter);
            var pdfReport = reportManagerPdf.GetReport(businessobj);
            Console.WriteLine(pdfReport);

            ReportManager<object> reportManagerXlsx = new(ReportFormatPlugins<object>.XLSXReportWriter);
            var xlsxReport = reportManagerXlsx.GetReport(businessobj);
            Console.WriteLine(xlsxReport);
        }
    }
    
   
}

