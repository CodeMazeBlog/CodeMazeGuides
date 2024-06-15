using System.Linq.Expressions;

namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private const string Job1 = "job-1";
    private const string Job2 = "job-2";
    private const string Job3 = "job-3";
    
    private readonly JobService _jobService;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly ILogger<JobsController> _logger;

    public JobsController(JobService jobService, IBackgroundJobClient backgroundJobClient, 
        ILogger<JobsController> logger)
    {
        _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        
        _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<StatisticsDto> GetStatistics()
    {
        var monitoringApi = JobStorage.Current.GetMonitoringApi();
        var statistics = monitoringApi.GetStatistics();
        
        var statisticsDto = new StatisticsDto
        {
            Processing = statistics.Processing,
            Enqueued = statistics.Enqueued,
            Scheduled = statistics.Scheduled,
            Recurring = statistics.Recurring
        };
        
        return Ok(statisticsDto);
    }
    
    [HttpPost("create-recurring-job/{number:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateRecurringJob(int number)
    {
        var jobName = $"job-{number}";
        
        switch (jobName) 
        {
            case Job1:
                _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job1());
                break;
            case Job2:
                _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job2());
                break;
            case Job3:
                _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job3());
                break;
            default:
                return BadRequest("Invalid job number.");
        }
        
        _logger.LogInformation("Created job '{JobName}'", jobName);
        
        return NoContent();
    }
}