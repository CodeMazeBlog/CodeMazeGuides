using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ReferenceTypeHelpersUnitTest
    {
        [Fact]
        public void GivenReferenceType_WhenReferenceUnInitialized_ThenThrowNullReferenceException()
        {
            var continents = new List<string> { "Asia", "Africa", "Europe", "Australia", "North America", "South America", "Middle East" };
            var continent = ReferenceTypeHelpers.FindItem(continents, "America");

            Assert.Null(continent);
            Assert.Throws<NullReferenceException>(()=> continent.ToLower());
        }
    }
}