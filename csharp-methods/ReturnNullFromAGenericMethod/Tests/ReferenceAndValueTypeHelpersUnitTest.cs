using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ReferenceAndValueTypeHelpersUnitTest
    {
        [Fact]
        public void GivenReferenceType_WhenDefaultValue_ThenThrowNullReferenceException_()
        {
            var continents = new List<string> { "Asia", "Africa", "Europe", "Australia", "North America", "South America", "Middle East" };
            var continent = ReferenceAndValueTypeHelpers.FindItemOrDefault(continents, "America");

            Assert.Null(continent);
            Assert.Throws<NullReferenceException>(() => continent.ToLower());
        }

        [Fact]
        public void GivenNullableValueType_WhenDefaultValue_ThenThrowInvalidOperationException()
        {
            var numbers = new List<int?> { 1, 2, 3, 4, 5 };
            var number = ReferenceAndValueTypeHelpers.FindItemOrDefault(numbers, 6);

            Assert.Null(number);
            Assert.Throws<InvalidOperationException>(() => number.Value);
        }

        [Fact]
        public void GivenIntegerValueType_WhenDefaultValue_ThenReturnZero()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var number = ReferenceAndValueTypeHelpers.FindItemOrDefault(numbers, 6);

            Assert.Equal(0, number);
        }
    }
}
