using GetListOfProperties;
using GetListOfProperties.Entity;
using System.Reflection;

namespace Tests
{
    public class Tests
    {
        private readonly PropertiesRetriever _propertiesRetriever;

        public Tests()
        {
            _propertiesRetriever = new();
        }

        [Fact]
        public void GivenPersonObject_WhenCallTheRetrievePropertiesMethod_ThenReturnPropertiesInfo()
        {
            var person = new Person();

            var properties = _propertiesRetriever.RetrieveProperties(person);

            Assert.NotNull(properties);
            Assert.Equal(3, properties.Length);
            Assert.Contains(properties, x => x.Name == "FirstName");
            Assert.Contains(properties, x => x.Name == "LastName");
            Assert.Contains(properties, x => x.Name == "Age");
        }

        [Fact]
        public void GivenAnUserObject_WhenCallTheRetrievePropertiesWithFilterMethod_ThenReturnPublicPropertiesInfo()
        {
            var user = new User();

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var properties = _propertiesRetriever.RetrievePropertiesWithFilter(user, flags);

            Assert.NotNull(properties);
            Assert.Equal(4, properties.Length);
            Assert.Contains(properties, x => x.Name == "FirstName");
            Assert.Contains(properties, x => x.Name == "LastName");
            Assert.Contains(properties, x => x.Name == "Age");
            Assert.Contains(properties, x => x.Name == "Email");
        }

        [Fact]
        public void GivenAnUserObject_WhenCallTheRetrievePropertiesWithFilterMethod_ThenReturnPublicNonPublicPropertiesInfo()
        {
            var user = new User();

            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var properties = _propertiesRetriever.RetrievePropertiesWithFilter(user, flags);

            Assert.NotNull(properties);
            Assert.Equal(5, properties.Length);
            Assert.Contains(properties, x => x.Name == "FirstName");
            Assert.Contains(properties, x => x.Name == "LastName");
            Assert.Contains(properties, x => x.Name == "Age");
            Assert.Contains(properties, x => x.Name == "Email");
            Assert.Contains(properties, x => x.Name == "Password");
        }

        [Fact]
        public void GivenAnUserObject_WhenCallTheRetrievePropertiesWithFilterMethod_ThenReturnNonPublicPropertiesInfo()
        {
            var user = new User();

            var flags = BindingFlags.Instance | BindingFlags.NonPublic;

            var properties = _propertiesRetriever.RetrievePropertiesWithFilter(user, flags);

            Assert.NotNull(properties);
            Assert.Single(properties);
            Assert.Contains(properties, x => x.Name == "Password");
        }

        [Fact] 
        public void GivenAnUserObject_WhenCallTheRetrieveParentClassPropertiesWithFilter_ThenReturnPublicPropertiesInfo()
        {
            var user = new User();

            var flags = BindingFlags.Instance | BindingFlags.Public;

            var properties = _propertiesRetriever.RetrieveParentClassPropertiesWithFilter(user, flags);

            Assert.NotNull(properties);
            Assert.Equal(3, properties.Length);
            Assert.Contains(properties, x => x.Name == "FirstName");
            Assert.Contains(properties, x => x.Name == "LastName");
            Assert.Contains(properties, x => x.Name == "Age");
        }
    }
}