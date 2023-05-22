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

    public class Referee :Employee 
    {
        [Required]
        public string RefereeCode { get; set; }

        [Required]
        public string LicenceNo { get; set; }

        [Required]
        public string Category { get; set; }
    }

    public class Organizer : Employee
    {
        [Required]
        public string OrganizerCode { get; set; }

        [Required]
        public int NoOfEventsOrganized { get; set; }
    }
}
