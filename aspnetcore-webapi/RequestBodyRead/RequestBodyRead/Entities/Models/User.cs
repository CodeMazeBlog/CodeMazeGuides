using System;
using System.ComponentModel.DataAnnotations;

namespace RequestBodyRead.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is a required field.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field")]
        public string? Email { get; set; }
    }
}

