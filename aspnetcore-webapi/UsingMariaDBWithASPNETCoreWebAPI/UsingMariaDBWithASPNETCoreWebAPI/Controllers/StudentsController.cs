using Microsoft.AspNetCore.Mvc;
using UsingMariaDBWithASPNETCoreWebAPI.Models;
using UsingMariaDBWithASPNETCoreWebAPI.Models.Contracts;

namespace UsingMariaDBWithASPNETCoreWebAPI.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController(IDataRepository dataRepository) : ControllerBase
{
    private readonly IDataRepository _dataRepository = dataRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _dataRepository.GetAllAsync();

        return Ok(students);
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _dataRepository.GetAsync(id);
        if (student is null)
        {
            return NotFound("Student not found.");
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> PostStudent([FromBody] Student student)
    {
        if (student is null)
        {
            return BadRequest("Student is null.");
        }
        await _dataRepository.AddAsync(student);

        return CreatedAtRoute("GetStudent", new { student.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, [FromBody] Student student)
    {
        if (student is null)
        {
            return BadRequest("Student is null.");
        }

        var studentToUpdate = await _dataRepository.GetAsync(id);
        if (studentToUpdate is null)
        {
            return NotFound("The Student record couldn't be found.");
        }
        await _dataRepository.UpdateAsync(studentToUpdate, student);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _dataRepository.GetAsync(id);
        if (student is null)
        {
            return NotFound("The Student record couldn't be found.");
        }
        await _dataRepository.DeleteAsync(student);

        return NoContent();
    }
}