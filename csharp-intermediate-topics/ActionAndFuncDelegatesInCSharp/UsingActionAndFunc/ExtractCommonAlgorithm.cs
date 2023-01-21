namespace UsingActionAndFunc
{
    using System;

    public class ExtractCommonAlgorithm
    {
        public ExtractCommonAlgorithm()
        {
            var persons = new List<Person>
            { 
                new () { Name = "Jon", Age = 15 },
                new () { Name = "Bob", Age = 20 },
                new () { Name = "Mike", Age = 35 }
            };

            var personsService = new PersonsService();

            // call simple methods to get adults and retired
            var adults = personsService.GetAdults(persons);
            var retired = personsService.GetRetired(persons);

            adults = persons.Where(person => person.Age > 18).ToList();

            // call generic list extension method
            adults = persons.Filter(person => person.Age > 18);
            retired = persons.Filter(person => person.Age > 65);
        }
    }
}
