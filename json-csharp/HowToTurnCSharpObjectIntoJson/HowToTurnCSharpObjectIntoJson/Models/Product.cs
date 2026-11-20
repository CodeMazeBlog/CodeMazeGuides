namespace HowToTurnCSharpObjectIntoJson.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;

        public int? Stock { get; set; }

        public DateTime? DateAcquired { get; set; }
    }
}
