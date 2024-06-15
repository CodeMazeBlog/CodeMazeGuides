namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    public readonly string Job1 = "job-1";
    public readonly string Job2 = "job-2";
    public readonly string Job3 = "job-3";
    
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager,
        ILogger<JobsController> logger)
    {
        _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        _recurringJobManager = recurringJobManager;

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
    
    [HttpPost("create-job-1")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateJob(int number)
    {
        _logger.LogInformation("Creating job '{JobName}'", Job1);

        var jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.RunJob1Async());
        
        _logger.LogInformation("Created job '{JobName}' with ID '{JobId}'", Job1, jobId);
        
        return NoContent();
    }
    
    [HttpPost("create-job-2")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateJob2()
    {
        _logger.LogInformation("Creating recurring job '{JobName}'", Job2);
        
        _recurringJobManager.AddOrUpdate<JobService>(Job2, jobService => jobService.RunJob2Async(), Cron.Minutely);
        
        return NoContent();
    }
    
    [HttpPost("create-job-3")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateJob3()
    {
        _logger.LogInformation("Creating job '{JobName}'", Job3);
        
        var jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.RunJob3Async());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            _logger.LogWarning("Unable to create job '{JobName}' probably it is already running", Job3);
            
            return NoContent();
        }
        
        _logger.LogInformation("Created job '{JobName}' with ID '{JobId}'", Job3, jobId);
        
        return NoContent();
    }
}