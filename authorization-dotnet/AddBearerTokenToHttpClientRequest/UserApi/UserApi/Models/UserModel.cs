using System.Text.Json.Serialization;

namespace UserApi.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get => FirstName + LastName; }
    }
}
