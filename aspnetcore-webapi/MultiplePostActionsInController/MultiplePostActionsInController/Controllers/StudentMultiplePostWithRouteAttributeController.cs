using Microsoft.AspNetCore.Mvc;

using MultiplePostActionsInController.Models;
using MultiplePostActionsInController.Services;

namespace MultiplePostActionsInController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentMultiplePostWithRouteAttributeController : ControllerBase
    {
        private readonly StudentInfoService _studentInfoService;
        private readonly StudentGradeService _studentGradeService;

        public StudentMultiplePostWithRouteAttributeController(StudentInfoService studentInfoService,
            StudentGradeService studentGradeService)
        {
            _studentInfoService = studentInfoService;
            _studentGradeService = studentGradeService;
        }

        [Route("PostStudentInfo")]
        [HttpPost]
        public ActionResult PostStudentInfo(StudentInfo info)
        {
            _studentInfoService.Add(info);
            return Ok();
        }

        [Route("PostStudentGrade")]
        [HttpPost]
        public ActionResult PostStudentGrade(StudentGrade grade)
        {
            _studentGradeService.Add(grade);
            return Ok();
        }
    }
}
