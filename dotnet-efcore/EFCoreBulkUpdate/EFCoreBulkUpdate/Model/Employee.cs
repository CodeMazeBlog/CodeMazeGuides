using System.ComponentModel.DataAnnotations;

namespace EFCoreBulkUpdate.Model
{
    //TPC
    public abstract class Employee
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int YearsExperience { get; set; }
    }
}