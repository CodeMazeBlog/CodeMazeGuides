using Microsoft.AspNetCore.Mvc;
using UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels;
using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.Contracts.IDataRepository;

namespace WebAPIOne.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController(IDataRepository<Course, CourseDto> dataRepository) : ControllerBase
    {
        private readonly IDataRepository<Course, CourseDto> _dataRepository = dataRepository;

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _dataRepository.GetAll();

            return Ok(courses);
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public IActionResult Get(int id)
        {
            var course = _dataRepository.GetDto(id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post(CourseDto course)
        {
            if (course is null)
            {
                return BadRequest("Course is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(course);

            return CreatedAtRoute("GetCourse", new { course.Id }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseDto course)
        {
            if (course is null)
            {
                return BadRequest("Course is null.");
            }

            var courseToUpdate = _dataRepository.Get(id);
            if (courseToUpdate is null)
            {
                return NotFound("The Course record couldn't be found.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(courseToUpdate, course);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _dataRepository.Get(id);
            if (course == null)
            {
                return NotFound("The Course record couldn't be found.");
            }
            _dataRepository.Delete(course);

            return NoContent();
        }
    }
}