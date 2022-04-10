
using ActionAndFuncInCsharp;
using Xunit;

namespace Tests
{
    public class PersonGreeterTest
    {
        [Fact]
        public void WhenGreetingPersonWithBasicDelegate_ThenPersonAddedToList()
        {
            var person = new Person("John", "Gates");
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithBasicDelegate(person);
            Assert.Equal(personGreeter.greetedPeople[0], person);

        }

        [Fact]
        public void WhenGreetingPersonWithAction_ThenPersonAddedToList()
        {
            var person = new Person("John", "Jobs");
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithAction(person);
            Assert.Equal(personGreeter.greetedPeople[0], person);

        }

        [Fact]
        public void WhenGreetingPersonWithShorterAction_ThenPersonAddedToList()
        {
            var person = new Person("Bill", "Gates");
            var personGreeter = new PersonGreeter();
            personGreeter.SayHelloWithShorterAction(person);
            Assert.Equal(personGreeter.greetedPeople[0], person);

        }

        [Fact]
        public void WhenGreetingPersonWithFunc_ThenPersonAddedToListAndReturned()
        {
            var person = new Person("John", "Jobs");
            var personGreeter = new PersonGreeter();
            var result = personGreeter.SayHelloWithFunc(person);
            Assert.Equal(personGreeter.greetedPeople[0].FirstName, person.FirstName);
            Assert.Equal(personGreeter.greetedPeople[0].LastName, person.LastName);
            Assert.Equal(person.FirstName, result.FirstName);
            Assert.Equal(person.LastName, result.LastName);
        }
    }
}