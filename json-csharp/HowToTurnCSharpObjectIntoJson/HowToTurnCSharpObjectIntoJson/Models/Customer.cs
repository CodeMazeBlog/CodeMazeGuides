using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Customer
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [JsonIgnore]
        public decimal FinancialRating { get; set; }
    }
}
