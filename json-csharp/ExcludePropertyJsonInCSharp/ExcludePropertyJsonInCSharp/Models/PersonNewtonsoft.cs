using Newtonsoft.Json;

namespace ExcludePropertyJsonInCSharp.Models
{
    public class PersonNewtonsoft
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}
