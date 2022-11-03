using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ReferenceTypeHelpersTests
    {
        [Fact]
        public void GivenReferenceType_ShouldThrowNullReferenceException_WhenReferenceUnInitialized()
        {
            var continents = new List<string> { "Asia", "Africa", "Europe", "Australia", "North America", "South America", "Middle East" };
            var continent = ReferenceTypeHelpers.FindItem(continents, "America");

            Assert.Null(continent);
            Assert.Throws<NullReferenceException>(()=> continent.ToLower());
        }
    }
}