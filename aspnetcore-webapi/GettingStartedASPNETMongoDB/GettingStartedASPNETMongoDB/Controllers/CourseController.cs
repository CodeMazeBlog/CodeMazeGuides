using Microsoft.AspNetCore.Mvc;
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;

namespace GettingStartedASPNETMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _CourseService;

        public CourseController(ICourseService service)
        {
            _CourseService = service;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Course>> GetById(string id)
        {
            var course = await _CourseService.GetById(id);

            return course is null ? NotFound() : Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            await _CourseService.Create(course);

            return CreatedAtAction(nameof(GetById),
                new { id = course.Id },
                course);
        }
    }
}