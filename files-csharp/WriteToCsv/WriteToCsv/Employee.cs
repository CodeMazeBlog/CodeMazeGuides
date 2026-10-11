using CsvHelper.Configuration.Attributes;

namespace WritingCSV
{
    // The two class-level attributes take effect only through
    // CsvConfiguration.FromAttributes<Employee>(); a CsvWriter built
    // from a CultureInfo alone ignores them.
    [Delimiter(";")]
    [HasHeaderRecord(false)]
    public class Employee
    {
        [Name("Identifier")]
        [Index(0)]
        public int Id { get; set; }

        [Name("Full Name")]
        [Index(1)]
        public string Name { get; set; } = string.Empty;

        [Index(2)]
        [Format("yyyy-MM-dd")]
        public DateTime Hired { get; set; }

        [Index(3)]
        [CultureInfo("en-US")]
        [Format("C")]
        public decimal Salary { get; set; }

        [Index(4)]
        [BooleanTrueValues("yes")]
        [BooleanFalseValues("no")]
        public bool Active { get; set; }

        [Index(5)]
        [Constant("EU")]
        public string Region { get; set; } = string.Empty;

        [Index(6)]
        [NullValues("N/A")]
        public string? Nickname { get; set; }

        [Ignore]
        public string Notes { get; set; } = string.Empty;
    }
}
