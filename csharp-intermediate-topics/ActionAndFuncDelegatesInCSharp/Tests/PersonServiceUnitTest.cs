namespace Tests
{
    using UsingActionAndFunc;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCallGetAdults_ThenOnlyAdultsShouldBeRetrieved()
        {
            var persons = Persons.GetAll();
            var personsService = new PersonsService();

            var adults = personsService.GetAdults(persons);

            Assert.IsNotNull(adults);
            Assert.AreEqual(2, adults.Count);
            Assert.IsTrue(adults.Exists(a => a.Name == "Bob"));
            Assert.IsTrue(adults.Exists(a => a.Name == "Mike"));
        }

        [Test]
        public void WhenCallGetRetired_ThenOnlyRetiredShouldBeRetrieved()
        {
            var persons = Persons.GetAll();
            var personsService = new PersonsService();

            var retired = personsService.GetRetired(persons);

            Assert.IsNotNull(retired);
            Assert.AreEqual(1, retired.Count);
            Assert.IsTrue(retired.Exists(a => a.Name == "Mike"));
        }
    }
}