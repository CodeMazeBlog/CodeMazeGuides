namespace CustomAttributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ManagerTaskAttribute : Attribute
{
    public Priorities Priority { get; set; }
    public bool NeedsReport { get; set; }
}
