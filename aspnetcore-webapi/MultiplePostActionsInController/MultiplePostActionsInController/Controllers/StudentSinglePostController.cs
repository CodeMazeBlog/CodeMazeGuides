using Microsoft.AspNetCore.Mvc;

using MultiplePostActionsInController.Models;
using MultiplePostActionsInController.Services;

using Newtonsoft.Json;

using System.IO;

namespace MultiplePostActionsInController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSinglePostController : ControllerBase
    {
        private readonly StudentInfoService _studentInfoService;
        private readonly StudentGradeService _studentGradeService;

        public StudentSinglePostController(StudentInfoService studentInfoService,
            StudentGradeService studentGradeService)
        {
            _studentInfoService = studentInfoService;
            _studentGradeService = studentGradeService;
        }

        [HttpPost]
        public ActionResult PostStudentInfo(StudentInfo info)
        {
            _studentInfoService.Add(info);
            return Ok();
        }

        [HttpPost]
        public ActionResult PostStudentGrade(StudentGrade grade)
        {
            _studentGradeService.Add(grade);
            return Ok();
        }
    }
}