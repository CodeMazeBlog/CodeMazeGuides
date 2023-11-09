using HowToTurnCSharpObjectIntoJson.Converters;
using Newtonsoft.Json;

namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Product
    {
        public string Name { get; set; }

        public int? Stock { get; set; }

        public DateTime? DateAcquired { get; set; }
    }
}
