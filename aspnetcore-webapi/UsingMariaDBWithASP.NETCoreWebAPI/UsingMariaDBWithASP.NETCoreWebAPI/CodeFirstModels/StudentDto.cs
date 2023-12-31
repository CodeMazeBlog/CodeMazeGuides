using System.ComponentModel.DataAnnotations;

namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a first name.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a second name.")]
        public string? SecondName { get; set; }

        public string? Address { get; set; }
    }
}