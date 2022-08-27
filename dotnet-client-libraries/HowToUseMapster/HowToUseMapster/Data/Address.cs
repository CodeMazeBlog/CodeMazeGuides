using Mapster;

namespace HowToUseMapster.Data
{
    //[GenerateMapper]
    public class Address
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
    }
}
