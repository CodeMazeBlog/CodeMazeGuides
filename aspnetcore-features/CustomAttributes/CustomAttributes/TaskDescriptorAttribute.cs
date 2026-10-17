namespace CustomAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class TaskDescriptorAttribute : Attribute
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool NeedsManager { get; set; }
    public int DeveloperCount { get; set; }
}
