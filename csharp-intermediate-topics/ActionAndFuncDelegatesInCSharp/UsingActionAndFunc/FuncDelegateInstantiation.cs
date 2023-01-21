namespace UsingActionAndFunc
{
    public class FuncDelegateInstantiation
    {
        public FuncDelegateInstantiation()
        {
            var persons = new List<Person>
            {
               new () { Name = "Jon", Age = 15 },
               new () { Name = "Bob", Age = 20 },
               new () { Name = "Mike", Age = 35 }
            };

            // reference existing methods
            Func<Person, bool> funcDelegate = PersonIsAdult;
            Func<Person, bool> funcDelegate1 = PersonIsRetired;

            // reference anonymous function
            Func<Person, bool> funcDelegate2 = delegate(Person person)
            {
                return person.Age > 18;
            };

            // reference lambda expression
            Func<Person, bool> funcDelegate3 = person => person.Age > 18;

            // avoid to create delegate variable
            var adults = persons.Where(p => p.Age > 18);
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
