using System.Linq.Expressions;

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
    
    [HttpPost("create-recurring-job/{number:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateRecurringJob(int number)
    {
        var jobName = $"job-{number}";
        
        Expression<Action> methodCall;
        switch (jobName)
        {
            case Job1:
                methodCall = () => _jobService.Job1();
                break;
            case Job2:
                methodCall = () => _jobService.Job2();
                break;
            case Job3:
                methodCall = () => _jobService.Job3();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(jobName), jobName, "Invalid job name");
        }

        var cronExpression = Cron.Minutely();
        _recurringJobManager.AddOrUpdate(jobName, methodCall, cronExpression);
        
        _logger.LogInformation("Recurring job \"{JobName}\" created with cron expression: {CronExpression}", jobName, cronExpression);
        
        return NoContent();
    }
}