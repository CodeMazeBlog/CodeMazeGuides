using ActionAndFuncDelegateInCSharp;

namespace Tests
{
    [TestClass]
    public class ReportManagerTest
    {
        [TestMethod]
        public void WhenPDFReportWriter_ThenReportFileFormatShouldBePDF()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManagerPDF = new(ReportFormatPlugins<object>.PDFReportWriter);
            var pdfreportpath = reportManagerPDF.GetReport(businessobj);
            
            Assert.IsTrue(Path.GetExtension(pdfreportpath).Equals(".PDF", StringComparison.CurrentCultureIgnoreCase));
        }
        [TestMethod]
        public void WhenXLSXReportWriter_ThenReportFileFormatShouldBeXlSX()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManagerXLSX = new(ReportFormatPlugins<object>.XLSXReportWriter);
            var reportpath = reportManagerXLSX.GetReport(businessobj);
            
            Assert.IsTrue(Path.GetExtension(reportpath).Equals(".XLSX", StringComparison.CurrentCultureIgnoreCase));
        }
        [TestMethod]
        public void WhenNoReportFormatPluginIsUsedInReportManager_ThenReportFileFormatShouldBeCSV()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManager = new();
            var reportpath = reportManager.GetReport(businessobj);
           
            Assert.IsTrue(Path.GetExtension(reportpath).Equals(".TXT", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}