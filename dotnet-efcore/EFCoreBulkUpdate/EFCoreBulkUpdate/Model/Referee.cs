using System.ComponentModel.DataAnnotations;

namespace EFCoreBulkUpdate.Model
{
    public class Referee : Employee 
    {
        [Required]
        public string RefereeCode { get; set; }

        [Required]
        public string LicenceNo { get; set; }

        [Required]
        public string Category { get; set; }
    }
}