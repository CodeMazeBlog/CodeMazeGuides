namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private const string Job1 = "job-1";
    private const string Job2 = "job-2";
    private const string Job3 = "job-3";
    
    private readonly IJobService _jobService;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IJobService jobService, 
        IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager,
        ILogger<JobsController> logger)
    {
        _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        
        _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        _recurringJobManager = recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
        
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
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<JobDto> GetJob(string id)
    {
        var api = JobStorage.Current.GetMonitoringApi();
        var job = api.JobDetails(id);
        
        if (job == null)
        {
            return NotFound();
        }
        
        var jobDto = new JobDto
        {
            Id = id,
            CreatedAt = job.CreatedAt,
            StateName = job.History.LastOrDefault()?.StateName
        };
        
        return Ok(new JobDto { Id = id });
    }
    
    [HttpPost($"create-recurring-{Job1}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateJob1()
    {
        var cronExpression = Cron.Minutely();
        _recurringJobManager.AddOrUpdate(Job1, () => _jobService.Job1(), cronExpression);
        
        _logger.LogInformation("Recurring job \"{JobName}\" created with cron expression: {CronExpression}", Job1, cronExpression);
        
        return NoContent();
    }
    
    [HttpPost($"create-recurring-{Job2}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateJob2()
    {
        var cronExpression = Cron.Minutely();
        _recurringJobManager.AddOrUpdate(Job1, () => _jobService.Job1(), cronExpression);
        
        _logger.LogInformation("Recurring job \"{JobName}\" created with cron expression: {CronExpression}", Job1, cronExpression);
        
        return NoContent();         
    }
    
    [HttpPost($"create-{Job3}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateJob3()
    {
        var jobId = _backgroundJobClient.Enqueue(() => _jobService.Job3());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            return Problem("Failed to create job", statusCode: StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
}