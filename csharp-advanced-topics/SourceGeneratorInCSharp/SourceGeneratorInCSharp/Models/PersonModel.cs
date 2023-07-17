using Generator;

namespace SourceGeneratorInCSharp.Models
{
    [GenerateService]
    public class PersonModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
