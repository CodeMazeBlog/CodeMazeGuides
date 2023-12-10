using Newtonsoft.Json;

namespace RetrieveJSONProperty.DTOs;

public class Product
{
    [JsonProperty("productId")]
    public string ProductId { get; set; }

    [JsonProperty("productName")]
    public string ProductName { get; set; }
}
