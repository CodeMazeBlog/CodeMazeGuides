using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GettingStartedASPNETMongoDB.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    private readonly ICourseService _courseService;

    public StudentsController(IStudentService studentService, ICourseService courseService)
    {
        _studentService = studentService;

        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    => Ok(await _studentService.GetAll());

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Student>> GetById(string id)
    {
        var student = await _studentService.GetById(id);

        if (student is null)
        {
            return NotFound();
        }

        foreach (var course in student.Courses)
        {
            var studentCourse = await _courseService.GetById(course);

            if (studentCourse is not null)
            {
                student.CourseList.Add(studentCourse);
            }
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid request object");
        }

        var createdStudent = await _studentService.Create(student);

        return CreatedAtAction(nameof(GetById),
            new { id = createdStudent.Id },
            createdStudent);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Student updatedStudent)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid request object");
        }

        var queriedStudent = await _studentService.GetById(id);

        if (queriedStudent is null)
        {
            return NotFound();
        }

        await _studentService.Update(id, updatedStudent);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var student = await _studentService.GetById(id);

        if (student is null)
        {
            return NotFound();
        }

        await _studentService.Delete(id);

        return NoContent();
    }
}