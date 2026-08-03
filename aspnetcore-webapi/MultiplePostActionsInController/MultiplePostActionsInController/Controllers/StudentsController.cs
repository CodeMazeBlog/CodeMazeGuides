using Microsoft.AspNetCore.Mvc;

using MultiplePostActionsInController.Models;

namespace MultiplePostActionsInController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        readonly List<Student> students = new()
        {
            new Student(1, "Pedro Whitted"),
            new Student(2, "Lester Harvin"),
            new Student(3, "Phyllis Wiggins")
        };

        readonly List<StudentGrade> grades = new()
        {
            new StudentGrade(1, 3.2),
            new StudentGrade(2, 2.5),
            new StudentGrade(3, 3.7)
        };

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            students.Add(student);
            return StatusCode(201);
        }

        [HttpPost]
        public ActionResult AddGrade(StudentGrade grade)
        {
            grades.Add(grade);
            return StatusCode(201);
        }

        [Route("AddStudent")]
        [HttpPost]
        public ActionResult PostStudent(Student student)
        {
            students.Add(student);
            return StatusCode(201);
        }

        [HttpPost("AddGrade")]
        public ActionResult PostGrade(StudentGrade grade)
        {
            grades.Add(grade);
            return StatusCode(201);
        }
    }
}