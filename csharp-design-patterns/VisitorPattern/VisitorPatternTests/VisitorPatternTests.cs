using NUnit.Framework;
using TeamA.TestResults;
using TeamA.TestResults.Results;
using TeamB.Detectors.Detectors;

namespace TeamC.Application.Visitor
{
    public class VisitorPatternTests
    {
        [Test]
        public void TestTheCodeWithVisitorPattern()
        {
            var testResults = new List<ISicknessAlertVisitable>() { new BloodSample(), new XRayImage(), new EcgReading() };
            var detectors = new List<ISicknessAlertVisitor>() { new CancerDetector(), new HivDetector() };
            var monitor = new TestResultsMonitoringApp(detectors);
            monitor.AnalyzeResultsBatch(testResults);
        }
    }
}