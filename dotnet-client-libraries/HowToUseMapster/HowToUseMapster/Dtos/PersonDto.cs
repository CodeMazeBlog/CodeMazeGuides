using Mapster;

namespace HowToUseMapster.Dtos
{
    public class PersonDto
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? AddressStreet { get; set; }

        public void SayHello()
        {
            Console.WriteLine("Hello...");
        }

        public void SayGoodbye()
        {
            Console.WriteLine("Goodbye...");
        }
    }
}
