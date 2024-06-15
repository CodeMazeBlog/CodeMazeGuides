using HowToPreventAHangfireJobFromRunning.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HowToPreventAHangfireJobFromRunning.Controllers;

[ApiController]
[Route("/jobs")]
public class JobsController : ControllerBase
{
    private readonly ILogger<JobsController> _logger;

    public JobsController(ILogger<JobsController> logger)
    {
        _logger = logger;
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
    public IActionResult CreateJob1()
    {
        var jobId = "job-1";

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
    
    [HttpPost("create-job-2")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateJob2()
    {
        var jobId = "job-2";

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
    
    [HttpPost("create-job-3")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateJob3()
    {
        var jobId = "job-3";

        return CreatedAtAction(nameof(GetJob), new { id = jobId }, new JobDto { Id = jobId });
    }
}