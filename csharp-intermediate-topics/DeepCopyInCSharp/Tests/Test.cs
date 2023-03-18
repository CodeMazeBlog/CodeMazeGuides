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
            var copy = DeepCopyMaker.DeepCopyXML(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingJsonSerializationAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyJSON(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingDataContractSerializationAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyDataContract(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingReflectionAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyReflection(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingExpressionTreesAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyExpressionTrees(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingAutoMApperAllPropertiesCopied()
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
        public void WhenUsingFastDeepClonerAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyFastDeepCloner(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingDeepCopyLibraryAllPropertiesCopied()
        {
            var copy = DeepCopyMaker.DeepCopyLibraryDeepCopy(_person);

            Assert.Equal(copy.Name, _person.Name);
            Assert.Equal(copy.Age, _person.Age);
            Assert.Equal(copy.Address.Street, _person.Address.Street);
            Assert.Equal(copy.Address.City, _person.Address.City);
            Assert.Equal(copy.Address.State, _person.Address.State);
        }

        [Fact]
        public void WhenUsingJsonDotNetAllPropertiesCopied()
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