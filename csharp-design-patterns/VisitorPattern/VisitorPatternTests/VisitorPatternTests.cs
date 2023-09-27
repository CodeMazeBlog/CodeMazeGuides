using NUnit.Framework;
using TeamA.TestResults;
using TeamA.TestResults.Results;
using TeamB.Detectors.Detectors;

namespace TeamC.Application.Visitor
{
    public class VisitorPatternTests
    {
        [Test]
        public void WhenProcessedSamples_ThenCorrectLogsProduced()
        {
            //capture console output to assert test results
            using var sw = new StringWriter();
            Console.SetOut(sw);

            //arrange
            var testResults = new List<ISicknessAlertVisitable>() { new BloodSample(), new XRayImage(), new EcgReading() };
            var detectors = new List<ISicknessAlertVisitor>() { new CancerDetector(), new HivDetector() };
            var monitor = new TestResultsMonitoringApp(detectors);
            
            //act
            _ = monitor.AnalyzeResultsBatch(testResults);

            //assert
            var logEntries = sw.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var expectedLogs = new string[]
            {
                "CancerDetector - Checking blood sample",
                "HivDetector - Checking blood sample",
                "CancerDetector - Checking X-Ray",
                "HivDetector - currently cannot detect HIV based on X-Ray",
                "CancerDetector - Checking ECG",
                "HivDetector - Checking ECG",
            };
            CollectionAssert.AreEquivalent(expectedLogs, logEntries);
        }
    }
}