namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly ILogger<JobsController> _logger;

    public JobsController(IJobService jobService, IBackgroundJobClient backgroundJobClient, 
        ILogger<JobsController> logger)
    {
        _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
        _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<JobDto>> GetJobs()
    {
        return Ok(new List<JobDto>
        {
            new JobDto { Id = "job-1" },
            new JobDto { Id = "job-2" },
            new JobDto { Id = "job-3" }
        });
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<JobDto> GetJob(string id)
    {
        return Ok(new JobDto { Id = id });
    }
    
    [HttpPost("create-job-1")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateJob1()
    {
        var jobId = _backgroundJobClient.Enqueue<IJobService>(service => service.Job1());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            return Problem("Failed to create job", statusCode: StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
    
    [HttpPost("create-job-2")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateJob2()
    {
        var jobId = _backgroundJobClient.Enqueue<IJobService>(service => service.Job2());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            return Problem("Failed to create job", statusCode: StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
    
    [HttpPost("create-job-3")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateJob3()
    {
        var jobId = _backgroundJobClient.Enqueue<IJobService>(service => service.Job3());
        
        if (string.IsNullOrWhiteSpace(jobId))
        {
            return Problem("Failed to create job", statusCode: StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
}