namespace HowToPreventAHangfireJobFromRunning.Dtos;

public class StatisticsDto
{
    public long Processing { get; set; }
    public long Enqueued { get; set; }
    public long Scheduled { get; set; }
    public long Recurring { get; set; }
}