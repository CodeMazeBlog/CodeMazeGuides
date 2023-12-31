using System.ComponentModel.DataAnnotations;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The course must have a title.")]
        public string? Title { get; set; }

        public int CreditUnit { get; set; }
    }
}