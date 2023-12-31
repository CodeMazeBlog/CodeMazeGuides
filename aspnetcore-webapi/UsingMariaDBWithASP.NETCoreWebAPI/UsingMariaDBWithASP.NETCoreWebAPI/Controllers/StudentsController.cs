using Microsoft.AspNetCore.Mvc;
using UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels;
using static UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.Contracts.IDataRepository;

namespace UsingMariaDBWithASP.NETCoreWebAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController(IDataRepository<Student, StudentDto> dataRepository) : ControllerBase
    {
        private readonly IDataRepository<Student, StudentDto> _dataRepository = dataRepository;

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _dataRepository.GetAll();

            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var student = _dataRepository.GetDto(id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post(StudentDto student)
        {
            if (student is null)
            {
                return BadRequest("Student is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Add(student);

            return CreatedAtRoute("GetStudent", new { student.Id }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentDto student)
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _dataRepository.Update(studentToUpdate, student);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            _dataRepository.Delete(student);

            return NoContent();
        }
    }
}