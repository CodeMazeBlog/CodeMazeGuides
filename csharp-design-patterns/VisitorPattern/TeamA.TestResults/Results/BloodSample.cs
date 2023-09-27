using TeamA.TestResults.ExtensibilityContract;

namespace TeamA.TestResults.Results
{
    public class BloodSample : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }
}