using TeamA.TestResults.ExtensibilityContract;

namespace TeamA.TestResults.Results
{
    public class XRayImage : ISicknessAlertVisitable
    {
        public AlertReport Accept(ISicknessAlertVisitor visitor) => visitor.Visit(this);
    }
}