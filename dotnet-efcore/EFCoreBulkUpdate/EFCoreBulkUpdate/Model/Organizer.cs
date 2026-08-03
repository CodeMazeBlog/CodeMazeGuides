using System.ComponentModel.DataAnnotations;

namespace EFCoreBulkUpdate.Model
{
    public class Organizer : Employee
    {
        [Required]
        public string OrganizerCode { get; set; }

        [Required]
        public int NoOfEventsOrganized { get; set; }
    }
}
