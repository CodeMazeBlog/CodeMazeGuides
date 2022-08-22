using System.ComponentModel.DataAnnotations;

namespace APIReturnType.Controllers
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}