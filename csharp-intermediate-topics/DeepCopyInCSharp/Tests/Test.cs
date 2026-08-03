using DeepCopyInCSharp;

namespace Tests
{
    public class Test
    {
        private readonly Person _person = new Person
        {
            Name = "Steve Doe",
            Age = 30,
            Address = new Address
            {
                Street = "123 Main St.",
                City = "Anytown",
                State = "AB"
            }
        };

        [Fact]
        public void WhenUsingICloneable_ThenAllPropertiesCopied()
        {
            var copy = (Person)_person.Clone();

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingXMLSerialization_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyXML(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingJsonSerialization_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyJSON(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingDataContractSerialization_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyDataContract(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingReflection_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyReflection(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingExpressionTrees_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyExpressionTrees(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingAutoMApper_ThenAllPropertiesCopied()
        {
            var copier = new DeepCopyMaker();
            var copy = copier.DeepCopyAutoMapper(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingFastDeepCloner_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyFastDeepCloner(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingDeepCopyLibrary_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyLibraryDeepCopy(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingJsonDotNet_ThenAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyJsonDotNet(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }
    }
}