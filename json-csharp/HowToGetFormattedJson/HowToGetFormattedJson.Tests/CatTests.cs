using FluentAssertions;

namespace HowToGetFormattedJson.Tests
{
    public class CatTests
    {
        [Fact]
        public void GivenAValidCat_WhenToStringMethodIsInvoked_ThenToStringMethodMethodReturnsExpectedOutput()
        {
            var cat = new Cat
            {
                Name = "One",
                Breed = "Two",
                Age = 3,
                FavoriteToys = new List<string> { "Four" },
                FavoriteFoods = new List<string> { "Five", "Six" }
            };

            var result = cat.ToString();

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }
    }
}
