namespace HowToPreventAHangfireJobFromRunning.Dtos;

public class JobDto
{
    public string Id { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public string? StateName { get; set; }
}