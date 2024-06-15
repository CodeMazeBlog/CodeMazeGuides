namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private const string Job1 = "job-1";
    private const string Job2 = "job-2";
    
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager,
        ILogger<JobsController> logger)
    {
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
        };
        
        return Ok(statisticsDto);
    }
    
    [HttpPost("create-job-1")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateJob1()
    {
        _logger.LogInformation("Creating job '{JobName}'", Job1);

        var jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.RunJob1Async());
        
        _logger.LogInformation("Created job '{JobName}' with ID '{JobId}'", Job1, jobId);
        
        return NoContent();
    }
    
    [HttpPost("create-job-2")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateJob2()
    {
        _logger.LogInformation("Creating job '{JobName}'", Job2);
        
        var jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.RunJob2Async());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            _logger.LogWarning("Unable to create job '{JobName}' probably it is already running", Job2);
            
            return NoContent();
        }
        
        _logger.LogInformation("Created job '{JobName}' with ID '{JobId}'", Job2, jobId);
        
        return NoContent();
    }
}