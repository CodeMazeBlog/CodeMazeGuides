using HowToTurnCSharpObjectIntoJson.Converters;
using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [JsonConverter(typeof(GeneralDateTimeConverter))]
        public DateTime BirthDate { get; set; }
    }
}
