using FluentAssertions;

namespace HowToCloneAList.Tests
{
    public class ToppingsListTests
    {
        [Fact]
        public void GivenAValidToppingsList_WhenCloneMethodIsInvoked_ThenCloneMethodReturnsNewToppingsListInstance()
        {
            var customToppingsList = new ToppingsList<string>
            {
                "Mozzarella",
                "Olive oil",
                "Basil"
            };

            var customToppingsListClone = (ToppingsList<string>)customToppingsList.Clone();

            customToppingsListClone.Should().BeEquivalentTo(customToppingsList);
        }
    }
}
