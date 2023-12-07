using Newtonsoft.Json;
namespace RetrieveJSONProperty.DTOs;

public class Sales
{
    [JsonProperty("Slx_PER_Year")]
    public string YearlySales { get; set; }

    [JsonProperty("Slx_PER_DAY")]
    public string DailySales { get; set; }
}
