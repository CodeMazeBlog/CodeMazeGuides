using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DataLayer.Entities
{
    internal class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedById { get; set; }
        public string AssignedToId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser AssignedTo { get; set; }
    }
}
