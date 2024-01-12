using Microsoft.AspNetCore.Mvc;
using UsingMariaDBWithASPNETCoreWebAPI.Models;
using UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts;

namespace UsingMariaDBWithASPNETCoreWebAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController(IDataRepository dataRepository) : ControllerBase
    {
        private readonly IDataRepository _dataRepository = dataRepository;

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _dataRepository.GetAll();

            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(int id)
        {
            var student = _dataRepository.Get(id);
            if (student is null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult PostStudent(Student student)
        {
            if (student is null)
            {
                return BadRequest("Student is null.");
            }
            _dataRepository.Add(student);

            return CreatedAtRoute("GetStudent", new { student.Id }, null);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (student is null)
            {
                return BadRequest("Student is null.");
            }

            var studentToUpdate = _dataRepository.Get(id);
            if (studentToUpdate is null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            _dataRepository.Update(studentToUpdate, student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _dataRepository.Get(id);
            if (student is null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            _dataRepository.Delete(student);

            return NoContent();
        }
    }
}