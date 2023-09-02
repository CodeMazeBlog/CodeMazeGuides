using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GettingStartedASPNETMongoDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService service)
    {
        _courseService = service;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Course>> GetById(string id)
    {
        var course = await _courseService.GetById(id);

        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        var createdCourse = await _courseService.Create(course);

        return CreatedAtAction(nameof(GetById),
            new { id = createdCourse.Id },
            createdCourse);
    }
}
