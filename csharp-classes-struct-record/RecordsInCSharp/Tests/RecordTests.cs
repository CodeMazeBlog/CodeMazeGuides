using RecordsInCSharpExample;
using Xunit;

namespace Tests
{
    public class RecordTests
    {
        [Fact]
        public void GivenTwoRecordsWithTheSameDefinitionAndValues_WhenWeUseTheEqualsOperator_ThenTheResultIsTrue()
        {
            // Arrange.
            var person1 = new Person("Joe", "Bloggs");
            var person2 = new Person("Joe", "Bloggs");

            // Act.
            var equal = person1 == person2;

            // Assert.
            Assert.True(equal);
        }

        [Fact]
        public void GivenTwoRecordsWithTheSameDefinitionButDifferentValues_WhenWeUseTheEqualsOperator_ThenTheResultIsFalse()
        {
            // Arrange.
            var person1 = new Person("Joe", "Bloggs");
            var person2 = new Person("Jane", "Bloggs");

            // Act.
            var equal = person1 == person2;

            // Assert.
            Assert.False(equal);
        }

        [Fact]
        public void GivenARecord_WhenWeUseTheWithOperatorToCloneTheRecord_ThenTheNewRecordInheritsTheValues()
        {
            // Arrange.
            var person1 = new Person("Joe", "Bloggs");

            // Act.
            var person2 = person1 with { FirstName = "Jane" };

            // Assert.
            Assert.Equal(person2.LastName, person1.LastName);
        }
    }
}