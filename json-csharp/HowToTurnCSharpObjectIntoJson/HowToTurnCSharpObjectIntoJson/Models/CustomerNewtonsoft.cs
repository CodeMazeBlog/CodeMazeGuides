using Newtonsoft.Json;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class CustomerNewtonsoft
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [JsonIgnore]
        public decimal FinancialRating { get; set; }
    }
}
