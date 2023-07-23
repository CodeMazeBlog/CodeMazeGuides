using FluentAssertions;

namespace HowToCloneAList.Tests
{
    public class PizzaTests
    {
        [Fact]
        public void GivenAValidPizza_WhenCopyConstructorIsInvoked_ThenConstructorReturnsNewPizzaInstance()
        {
            var margherita = new Pizza
            {
                Name = "Margherita",
                Toppings = new List<string>
                {
                    "Mozzarella",
                    "Olive oil",
                    "Basil"
                }
            };

            var margheritaClone = new Pizza(margherita);

            margheritaClone.Should().BeEquivalentTo(margherita);
        }

        [Fact]
        public void GivenAValidPizza_WhenCloneMethodIsInvoked_ThenCloneMethodReturnsNewPizzaInstance()
        {
            var margherita = new Pizza
            {
                Name = "Margherita",
                Toppings = new List<string>
                {
                    "Mozzarella",
                    "Olive oil",
                    "Basil"
                }
            };

            var margheritaClone = (Pizza)margherita.Clone();

            margheritaClone.Should().BeEquivalentTo(margherita);
        }

        [Fact]
        public void GivenAValidPizza_WhenToStringMethodIsInvoked_ThenToStringMethodMethodReturnsExpectedOutput()
        {
            var margherita = new Pizza
            {
                Name = "Margherita",
                Toppings = new List<string>
                {
                    "Mozzarella",
                    "Olive oil",
                    "Basil"
                }
            };

            var expectedOutput = $"Pizza name: {margherita.Name}; Toppings: {string.Join(", ", margherita.Toppings)}"; ;

            expectedOutput.Should().Be(margherita.ToString());
        }
    }
}