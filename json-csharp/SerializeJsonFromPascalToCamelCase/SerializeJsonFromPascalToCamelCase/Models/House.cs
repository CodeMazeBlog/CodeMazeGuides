using Newtonsoft.Json.Linq;

namespace SerializeJsonFromPascalToCamelCase.Models;

public class House
{
    public int NoOfRooms { get; set; }

    public decimal SizeInSqft { get; set; }

    public JObject OtherDetails { get; set; }
}