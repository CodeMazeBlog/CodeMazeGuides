using System.ComponentModel.DataAnnotations;

namespace APIReturnType
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public bool IsActive { get; set; }
    }
}