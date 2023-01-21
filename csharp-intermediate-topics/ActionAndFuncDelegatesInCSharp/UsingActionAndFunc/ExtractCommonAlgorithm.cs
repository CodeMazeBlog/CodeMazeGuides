namespace UsingActionAndFunc
{
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

            // call simple methods to get adults and retired
            var adults = GetAdults(persons);
            var retired = GetRetired(persons);

            // call generic list extension method
            adults = persons.Filter(person => person.Age > 18);
            retired = persons.Filter(person => person.Age > 65);
        }

        private List<Person> GetAdults(List<Person> allPersons)
        {
            var list = new List<Person>();

            foreach (var person in allPersons)
            {
                if (PersonIsAdult(person))
                {
                    list.Add(person);
                } 
            }

            return list;
        }

        private List<Person> GetRetired(List<Person> allPersons)
        {
            var list = new List<Person>();

            foreach (var person in allPersons)
            {
                if (PersonIsRetired(person))
                {
                    list.Add(person);
                } 
            }

            return list;
        }

        private bool PersonIsAdult(Person person)
        {
            return person.Age > 18;
        }

        private bool PersonIsRetired(Person person)
        {
            return person.Age > 65;
        }
    }
}
