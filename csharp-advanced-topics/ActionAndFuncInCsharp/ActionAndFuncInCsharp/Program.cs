namespace ActionAndFuncInCsharp
{
    /// <summary>
    /// Action and function delegates basic usage.
    /// </summary>
    public class Program
    {
        delegate void SayHello(Person person);

        static Action<Person> SayHelloAction = HelloPerson;
        static Action<Person> ShorterSayHelloAction = (Person person) => Console.WriteLine($"Hello {person.FirstName} {person.LastName}");

        static Person him = new Person { FirstName = "John", LastName = "Doe" };


        static Func<string, string, Person>? CreateAndSayHelloDelegate;

        /// <summary>
        /// Init the console app.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            SayHelloWithBasicDelegate();
            SayHelloWithAction();
            SayHelloWithFunc();
        }

        /// <summary>
        /// Say Hello with basic delegate
        /// </summary>
        private static void SayHelloWithBasicDelegate()
        {
            var hello = new SayHello(HelloPerson);
            hello(him);
        }

        private static void SayHelloWithAction()
        {
            ShorterSayHelloAction(him);
        }

        /// <summary>
        /// Hello Person method.
        /// </summary>
        /// <param name="person">Person to greet.</param>
        private static void HelloPerson(Person person)
        {
            Console.WriteLine($"Hello {person.FirstName} {person.LastName}");

        }        

        /// <summary>
        /// Say hello with Func
        /// </summary>
        private static void SayHelloWithFunc()
        {
            CreateAndSayHelloDelegate += CreateAndSayHello;
            CreateAndSayHelloDelegate("John", "Doe");
        }
              
        /// <summary>
        /// Say Hello func implementation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        private static Person CreateAndSayHello(string firstName, string lastName)
        {
            Person person = new Person { FirstName = firstName, LastName = lastName };
            ShorterSayHelloAction(person);
            return person;
        }

    }

    /// <summary>
    /// Person class
    /// </summary>
    class Person
    {
        /// <summary>
        /// First name
        /// </summary>
        public string? FirstName { get; init; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string? LastName { get; init; }

    }



}