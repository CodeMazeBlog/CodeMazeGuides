using Microsoft.AspNetCore.Mvc;

using MultiplePostActionsInController.Models;
using MultiplePostActionsInController.Services;

namespace MultiplePostActionsInController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentMultiplePostWithHttpPostAttributeController : ControllerBase
    {
        private readonly StudentInfoService _studentInfoService;
        private readonly StudentGradeService _studentGradeService;

        public StudentMultiplePostWithHttpPostAttributeController(StudentInfoService studentInfoService,
            StudentGradeService studentGradeService)
        {
            _studentInfoService = studentInfoService;
            _studentGradeService = studentGradeService;
        }

        [HttpPost("PostStudentInfo")]
        public ActionResult PostStudentInfo(StudentInfo info)
        {
            _studentInfoService.Add(info);
            return Ok();
        }

        [HttpPost("PostStudentGrade")]
        public ActionResult PostStudentGrade(StudentGrade grade)
        {
            _studentGradeService.Add(grade);
            return Ok();
        }
    }
}
