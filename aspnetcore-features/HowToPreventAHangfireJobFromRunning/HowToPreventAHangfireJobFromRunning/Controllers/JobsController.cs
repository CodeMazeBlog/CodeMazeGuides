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
    
    [HttpGet("{jobId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<JobDto> GetJob(string jobId)
    {
        var monitoringApi = JobStorage.Current.GetMonitoringApi();
        var jobDetails = monitoringApi.JobDetails(jobId);
        
        if (jobDetails == null)
        {
            return NotFound();
        }
        
        var jobDto = new JobDto
        {
            Id = jobId,
            CreatedAt = jobDetails.CreatedAt,
            StateName = jobDetails.History.LastOrDefault()?.StateName
        };
        
        return Ok(jobDto);
    }
    
    [HttpPost("create-job/{number:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateJob(int number)
    {
        var jobName = $"job-{number}";
        string? jobId;
        
        switch (jobName) 
        {
            case Job1:
                jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job1());
                break;
            case Job2:
                jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job2());
                break;
            case Job3:
                jobId = _backgroundJobClient.Enqueue<JobService>(jobService => jobService.Job3());
                break;
            default:
                return BadRequest("Invalid job number.");
        }

        if (string.IsNullOrWhiteSpace(jobId))
        {
            _logger.LogWarning("Unable to create job '{JobName}'", jobName);
        }
        else
        {
            _logger.LogInformation("Created job '{JobName}' with ID '{JobId}'", jobName, jobId);
        }
        
        return NoContent();
    }
}