using System.Text.Json.Serialization;

namespace ExcludePropertyJsonInCSharp.Models
{
    public class Person
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
