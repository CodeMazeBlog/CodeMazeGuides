using TeamA.TestResults.ExtensibilityContract;

namespace TeamA.TestResults
{
    public interface ISicknessAlertVisitable
    {
        AlertReport Accept(ISicknessAlertVisitor visitor);
    }
}