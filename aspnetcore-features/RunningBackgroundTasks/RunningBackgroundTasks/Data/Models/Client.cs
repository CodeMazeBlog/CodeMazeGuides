namespace RunningBackgroundTasks.Data.Models;

public class Client
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public DateOnly FirstOrderDate { get; set; }
    public DateOnly LastOrderDate { get; set; }
    public bool IsActive { get; set; }
}
