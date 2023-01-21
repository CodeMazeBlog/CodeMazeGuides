namespace UsingActionAndFunc
{
    public class PersonsService
    {
        public List<Person> GetAdults(List<Person> allPersons)
        {
            var list = new List<Person>();

            foreach (var person in allPersons)
            {
                if (this.PersonIsAdult(person))
                {
                    list.Add(person);
                } 
            }

            return list;
        }

        public List<Person> GetRetired(List<Person> allPersons)
        {
            var list = new List<Person>();

            foreach (var person in allPersons)
            {
                if (this.PersonIsRetired(person))
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
