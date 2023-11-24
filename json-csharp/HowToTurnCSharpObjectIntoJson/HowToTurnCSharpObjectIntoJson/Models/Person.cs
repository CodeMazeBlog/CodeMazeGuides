using HowToTurnCSharpObjectIntoJson.Converters;
using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Person
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }

        [JsonConverter(typeof(GeneralDateTimeConverter))]
        public DateTime BirthDate { get; set; }
    }
}
