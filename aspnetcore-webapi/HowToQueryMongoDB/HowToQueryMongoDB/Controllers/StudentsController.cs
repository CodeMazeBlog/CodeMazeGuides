using HowToQueryMongoDB.Interfaces;
using HowToQueryMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace HowToQueryMongoDB.Controllers;

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

        if (student.Courses is null || !student.Courses.Any())
        {
            return Ok(student);
        }

        student.CourseList ??= new();

        foreach (var courseId in student.Courses)
        {
            var course = await _courseService.GetById(courseId) ?? throw new Exception("Invalid Course Id");

            student.CourseList.Add(course);
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        var createdStudent = await _studentService.Create(student);

        return createdStudent is null
            ? throw new Exception("Student creation failed")
            : CreatedAtAction(nameof(GetById),
            new { id = createdStudent.Id }, createdStudent);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Student updatedStudent)
    {
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

    [HttpGet("usingbuilder/{id:length(24)}")]
    public async Task<ActionResult<Student>> GetAStudentUsingBuilder(string id)
    => Ok(await _studentService.GetByIdUsingBuilder(id));

    [HttpGet("andrange")]
    public ActionResult<IEnumerable<Student>> GetRangeUsingAnd(string minimumId, string maximumId)
    => Ok(_studentService.GetRangeOfStudentsUsingAnd(minimumId, maximumId));

    [HttpGet("orrange")]
    public ActionResult<IEnumerable<Student>> GetRangeUsingOr(string minimumId, string maximumId)
        => Ok(_studentService.GetRangeOfStudentsUsingOr(minimumId, maximumId));

    [HttpGet("inlist")]
    public ActionResult<IEnumerable<Student>> GetInList(string objectIds)
        => Ok(_studentService.GetAllStudentsInTheList(objectIds));

}