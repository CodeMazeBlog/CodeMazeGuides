using System.Collections.Generic;
using TeamA.TestResults;
using TeamA.TestResults.ExtensibilityContract;

namespace TeamC.Application.Visitor
{
    public class TestResultsMonitoringApp
    {
        private readonly List<ISicknessAlertVisitor> detectors;

        public TestResultsMonitoringApp(List<ISicknessAlertVisitor> detectors)
        {
            this.detectors = detectors;
        }

        public List<AlertReport> AnalyzeResultsBatch(IEnumerable<ISicknessAlertVisitable> testResults)
        {
            var alertReports = new List<AlertReport>();

            foreach (var sample in testResults)
            {
                foreach (var detector in detectors)
                {
                    alertReports.Add(sample.Accept(detector));
                }
            }
            return alertReports;
        }
    }
}