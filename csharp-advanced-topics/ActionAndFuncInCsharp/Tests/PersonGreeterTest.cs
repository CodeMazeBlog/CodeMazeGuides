using ActionAndFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PersonGreeterTest
    {
        [TestMethod]
        public void WhenGreetingPersonWithBasicDelegate_ThenPersonAddedToList()
        {
            var person = new Person { FirstName = "John", LastName = "Gates" };
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithBasicDelegate(person);
            Assert.AreEqual(personGreeter.greetedPersons[0], person);

        }

        [TestMethod]
        public void WhenGreetingPersonWithAction_ThenPersonAddedToList()
        {
            var person = new Person { FirstName = "John", LastName = "Jobs" };
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithAction(person);
            Assert.AreEqual(personGreeter.greetedPersons[0], person);

        }

        [TestMethod]
        public void WhenGreetingPersonWithShorterAction_ThenPersonAddedToList()
        {
            var person = new Person { FirstName = "Bill", LastName = "Gates" };
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithShorterAction(person);
            Assert.AreEqual(personGreeter.greetedPersons[0], person);

        }

        [TestMethod]
        public void WhenGreetingPersonWithFunc_ThenPersonAddedToListAndReturned()
        {
            var person = new Person { FirstName = "John", LastName = "Jobs" };
            var personGreeter = new PersonGreeter();
            var result = personGreeter.SayHelloWithFunc(person);
            Assert.AreEqual(personGreeter.greetedPersons[0].FirstName, person.FirstName);
            Assert.AreEqual(personGreeter.greetedPersons[0].LastName, person.LastName);
            Assert.AreEqual(person.FirstName, result.FirstName);
            Assert.AreEqual(person.LastName, result.LastName);
        }
    }
}