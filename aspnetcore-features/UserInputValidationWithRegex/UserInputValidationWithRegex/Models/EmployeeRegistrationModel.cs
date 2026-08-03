using System.ComponentModel.DataAnnotations;

namespace UserInputValidationWithRegex.Models
{
    public class EmployeeRegistrationModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Employee name contains invalid characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+\s[a-zA-Z\s\-']{2,}.\s?[a-zA-Z\s\(\),]{2,}$",
                            ErrorMessage = "Wrong address format.")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}$|^[0-9]{5}-?[0-9]{4}$", ErrorMessage = "Invalid zip code format.")]
        public string ZipCode { get; set; }

        [Required]
        [RegularExpression(@"^(?!(000|666|9))\d{3}-(?!00)\d{2}-(?!0000)\d{4}$", ErrorMessage = "Invalid SSN.")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [RegularExpression(@"^[\w.\-]{2,18}$", ErrorMessage = "Invalid username.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,32}$", 
                            ErrorMessage = "Password doesn't meet security rules.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^((?!\.)[\w-_.]*[^.])(@\w+)(\.\w+(\.\w+)?[^.\W])$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([+]?\d{1,2}[-\s]?|)\d{3}[-\s]?\d{3}[-\s]?\d{4}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
