using CsvHelper.Configuration.Attributes;

namespace ReadFromCsv
{
    public class Person
    {
        [Index(0)]
        public int Id { get; set; }
        [Index(1)]
        public string? Name { get; set; }
        [Index(2)]
        public bool IsLiving { get; set; }
        [Index(3)]
        public DateTime DateOfBirth { get; set; }
    }
}
