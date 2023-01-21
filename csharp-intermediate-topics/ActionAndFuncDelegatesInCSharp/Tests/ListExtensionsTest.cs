namespace Tests
{
    using UsingActionAndFunc;

    public class ListExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCallFilter_ThenOnlyAdultsShouldBeRetrieved()
        {
            var persons = Persons.GetAll();

            var adults = persons.Filter(p => p.Age > 18);

            Assert.IsNotNull(adults);
            Assert.AreEqual(2, adults.Count);
            Assert.IsTrue(adults.Exists(a => a.Name == "Bob"));
            Assert.IsTrue(adults.Exists(a => a.Name == "Mike"));
        }

        [Test]
        public void WhenCallFilter_ThenOnlyRetiredShouldBeRetrieved()
        {
            var persons = Persons.GetAll();

            var retired = persons.Filter(p => p.Age > 65);

            Assert.IsNotNull(retired);
            Assert.AreEqual(1, retired.Count);
            Assert.IsTrue(retired.Exists(a => a.Name == "Mike"));
        }
    }
}
