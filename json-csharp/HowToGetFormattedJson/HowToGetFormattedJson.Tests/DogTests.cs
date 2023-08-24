using FluentAssertions;

namespace HowToGetFormattedJson.Tests
{
    public class DogTests
    {
        [Fact]
        public void GivenAValidDog_WhenToStringMethodIsInvoked_ThenToStringMethodMethodReturnsExpectedOutput()
        {
            var dog = new Dog
            {
                Name = "One",
                Breed = "Two",
                Age = 3,
                FavoriteToys = new List<string> { "Four" },
                FavoriteFoods = new List<string> { "Five", "Six" }
            };

            var result = dog.ToString();

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }
    }
}
