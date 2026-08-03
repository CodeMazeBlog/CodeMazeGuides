using TeamA.TestResults.ExtensibilityContract;
using TeamA.TestResults.Results;

namespace TeamA.TestResults
{
    public interface ISicknessAlertVisitor
    {
        AlertReport Visit(BloodSample blood);
        AlertReport Visit(XRayImage rtg);
        AlertReport Visit(EcgReading sample);
    }
}