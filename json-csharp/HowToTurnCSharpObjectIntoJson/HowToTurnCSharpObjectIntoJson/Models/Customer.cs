using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public decimal FinancialRating { get; set; }
    }
}
