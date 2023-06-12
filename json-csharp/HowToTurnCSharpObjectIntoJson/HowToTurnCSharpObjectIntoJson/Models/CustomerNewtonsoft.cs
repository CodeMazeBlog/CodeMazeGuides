using Newtonsoft.Json;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class CustomerNewtonsoft
    {
        public string Name { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public decimal FinancialRating { get; set; }
    }
}
