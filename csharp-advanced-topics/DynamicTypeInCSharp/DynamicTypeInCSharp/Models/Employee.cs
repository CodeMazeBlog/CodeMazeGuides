namespace DynamicTypeInCSharp.Models;

public class Employee
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public WorkStatus WorkStatus { get; set; } = WorkStatus.NotWorking;

    public WorkStatus GetWorkStatus()
    {
        return WorkStatus;
    }
}

public enum WorkStatus
{
    OnABreak,
    Working,
    NotWorking
}
