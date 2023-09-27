using CsvHelper.Configuration;
using ReadFromCsv;

public class PersonMap : ClassMap<Person> 
{ 
    public PersonMap() 
    { 
        Map(p => p.Id).Index(0); 
        Map(p => p.Name).Index(1); 
        Map(p => p.IsLiving).Index(2); 
    } 
}