using ReadFromCsv;

foreach (var person in ReadMethods.ReadPersons())
{
    Console.WriteLine($"{person.Id} {person.Name} {person.IsLiving}");
}
