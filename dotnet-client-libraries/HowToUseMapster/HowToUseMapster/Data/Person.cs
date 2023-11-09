using Mapster;

namespace HowToUseMapster.Data
{
    [AdaptTo("[name]Model"), GenerateMapper]
    public class Person
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address? Address { get; set; }
    }
}
