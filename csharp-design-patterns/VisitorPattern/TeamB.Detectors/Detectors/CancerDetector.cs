using TeamA.TestResults;
using TeamA.TestResults.ExtensibilityContract;
using TeamA.TestResults.Results;

namespace TeamB.Detectors.Detectors
{
    public class CancerDetector : ISicknessAlertVisitor
    {
        public AlertReport Visit(BloodSample blood)
        {
            Console.WriteLine($"{GetType().Name} - Checking blood sample");
            return new AlertReport();
        }

        public AlertReport Visit(XRayImage rtg)
        {
            Console.WriteLine($"{GetType().Name} - Checking Xray");
            return new AlertReport();
        }

        public AlertReport Visit(EcgReading sample)
        {
            Console.WriteLine($"{GetType().Name} - Checking ECG");
            return new AlertReport();
        }
    }
}