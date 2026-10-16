using CsvHelper.Configuration;

namespace WritingCSV
{
    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(p => p.Id).Name("Identifier").Index(0);
            Map(p => p.IsLiving).Index(1);
            Map(p => p.Name).Index(2);
        }
    }
}
