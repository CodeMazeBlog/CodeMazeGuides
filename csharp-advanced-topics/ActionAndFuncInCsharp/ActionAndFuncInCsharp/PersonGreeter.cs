namespace ActionAndFuncInCsharp
{
    /// <summary>
    /// Person Greeter class
    /// </summary>
    public class PersonGreeter
    {
        delegate void SayHello(Person person);
        Action<Person> SayHelloAction;
        Action<Person> ShorterSayHelloAction;
        Func<string, string, Person>? CreateAndSayHelloDelegate;

        /// <summary>
        /// Greeted persons
        /// </summary>
        public List<Person> greetedPersons { get; init; }

        /// <summary>
        /// person greeter new instance
        /// </summary>
        public PersonGreeter()
        {
            greetedPersons = new List<Person>();
            ShorterSayHelloAction = (Person person) => greetedPersons.Add(person);
            SayHelloAction = HelloPerson;
        }

        /// <summary>
        /// Say Hello with basic delegate
        /// </summary>
        public void SayHelloWithBasicDelegate(Person person)
        {
            var hello = new SayHello(HelloPerson);
            hello(person);
        }

        /// <summary>
        /// Hello him
        /// </summary>
        public void SayHelloWithShorterAction(Person him)
        {
            ShorterSayHelloAction(him);
        }

        /// <summary>
        /// Hello him
        /// </summary>
        public void SayHelloWithAction(Person him)
        {
            SayHelloAction(him);
        }

        /// <summary>
        /// Hello Person method.
        /// </summary>
        /// <param name="person">Person to greet.</param>
        public void HelloPerson(Person person)
        {
            greetedPersons.Add(person);
        }

        /// <summary>
        /// Say hello with Func
        /// </summary>
        public Person SayHelloWithFunc(Person him)
        {
            CreateAndSayHelloDelegate += CreateAndSayHello;
            return CreateAndSayHelloDelegate(him.FirstName, him.LastName);
        }

        /// <summary>
        /// Say Hello func implementation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Person CreateAndSayHello(string firstName, string lastName)
        {
            var person = new Person { FirstName = firstName, LastName = lastName };
            ShorterSayHelloAction(person);
            return person;
        }

    }
}