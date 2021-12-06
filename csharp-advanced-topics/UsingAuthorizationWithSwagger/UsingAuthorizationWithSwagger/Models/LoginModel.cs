using System.ComponentModel.DataAnnotations;

namespace UsingAuthorizationWithSwagger.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Email Required")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
