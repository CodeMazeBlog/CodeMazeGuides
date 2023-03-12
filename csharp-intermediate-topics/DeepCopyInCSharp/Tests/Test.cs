using DeepCopyInCSharp;

namespace Tests
{
    public class Test
    {
        private Person _person = new Person
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
        public void WhenUsingICloneableAllPropertiesCopied()
        {
            var copy = (Person)_person.Clone();

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingXMLSerializationAllPropertiesCopied()
        {
            var copy = DeepCopier.DeepCopyXML(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingJsonSerializationAllPropertiesCopied()
        {
            var copy = DeepCopier.DeepCopyJSON(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingDataContractSerializationAllPropertiesCopied()
        {
            var copy = DeepCopier.DeepCopyDataContract(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingReflectionAllPropertiesCopied()
        {
            var copy = DeepCopier.DeepCopyReflection(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingExpressionTreesAllPropertiesCopied()
        {
            var copy = DeepCopier.DeepCopyExpressionTrees(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }
    }
}