using System.ComponentModel.DataAnnotations;

namespace Localization.Models;

public class PersonViewModel
{
    [Display(Name = "FirstName")]
    [Required(ErrorMessage = "{0} is a required field")] 
    public string FirstName { get; set; }

    [Display(Name = "LastName")]
    [Required(ErrorMessage = "{0} is a required field")] 
    public string LastName { get; set; }

    [Display(Name = "Age")]
    [Range(1, 100, ErrorMessage = "{0} must be a number between {1} and {2}")] 
    public int Age { get; set; }
}
