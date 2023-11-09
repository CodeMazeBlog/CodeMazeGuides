using System.Text.Json.Serialization;

namespace WorkingWithRestSharp.DataTransferObject
{
    public class UserData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("First_Name")]
        public string FirstName { get; set; }
        [JsonPropertyName("Last_Name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
