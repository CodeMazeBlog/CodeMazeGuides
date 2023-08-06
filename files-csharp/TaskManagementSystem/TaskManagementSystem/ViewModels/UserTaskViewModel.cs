using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.ViewModels
{
    public class UserTaskViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string AsssignedToId { get; set; }
    }
}
