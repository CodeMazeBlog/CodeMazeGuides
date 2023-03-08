using ActionAndFuncDelegateInCSharp;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Check_GetReport_With_PDFDelegate_Plugin()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManager2 = new(ReportFormatPlugins<object>.PDFReportWriter);
            var reportpath = reportManager2.GetReport(businessobj);
            Assert.IsTrue(Path.GetExtension(reportpath).Equals(".PDF", StringComparison.CurrentCultureIgnoreCase));

        }
        [TestMethod]
        public void Check_GetReport_With_XLSXDelegate_Plugin()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManager3 = new(ReportFormatPlugins<object>.XLSXReportWriter);
            var reportpath = reportManager3.GetReport(businessobj);
            Assert.IsTrue(Path.GetExtension(reportpath).Equals(".XLSX", StringComparison.CurrentCultureIgnoreCase));
        }
        [TestMethod]
        public void Check_GetReport_With_TEXTDelegate_Plugin()
        {
            List<object> businessobj = new();
            ReportManager<object> reportManager = new();
            var reportpath = reportManager.GetReport(businessobj);
            Assert.IsTrue(Path.GetExtension(reportpath).Equals(".TXT", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}