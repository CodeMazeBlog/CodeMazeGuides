using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ReferenceAndValueTypeHelpersTests
    {
        [Fact]
        public void GivenReferenceType_ShouldThrowNullReferenceException_WhenReferenceUnInitialized()
        {
            var continents = new List<string> { "Asia", "Africa", "Europe", "Australia", "North America", "South America", "Middle East" };
            var continent = ReferenceAndValueTypeHelpers.FindItemOrDefault(continents, "America");

            Assert.Null(continent);
            Assert.Throws<NullReferenceException>(() => continent.ToLower());
        }

        [Fact]
        public void GivenValueType_ShouldThrowInvalidOperationException_WhenNullReturned()
        {
            var numbers = new List<int?> { 1, 2, 3, 4, 5 };
            var number = ReferenceAndValueTypeHelpers.FindItemOrDefault(numbers, 6);

            Assert.Null(number);
            Assert.Throws<InvalidOperationException>(() => number.Value);
        }
    }
}
