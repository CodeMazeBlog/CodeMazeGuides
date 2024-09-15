namespace RunningBackgroundTasks.Data;

public class Client
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime FirstOrderDate { get; set; }
    public DateTime LastOrderDate { get; set; }
    public bool IsActive { get; set; }
}
