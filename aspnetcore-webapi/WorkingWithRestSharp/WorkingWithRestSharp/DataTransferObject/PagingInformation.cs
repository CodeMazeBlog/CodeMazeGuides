using System.Text.Json.Serialization;

namespace WorkingWithRestSharp.DataTransferObject
{
    public class PagingInformation
    {
        public int Page { get; set; }
        [JsonPropertyName("Per_Page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonPropertyName("Total_Pages")]
        public int TotalPages { get; set; }
    }
}
