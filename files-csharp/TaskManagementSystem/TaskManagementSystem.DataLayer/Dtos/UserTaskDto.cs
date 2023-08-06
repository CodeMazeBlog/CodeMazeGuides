using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.DataLayer.Dtos
{
    public class UserTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedById { get; set; }
        public string AssignedToId { get; set; }
        public string LastModifiedById { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}
