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

        [Fact]
        public void GivenAListOfPizzas_WhenProjectedThroughTheCopyConstructor_ThenTheCloneKeepsItsToppings()
        {
            var pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Name = "Margherita",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Olive oil",
                        "Basil"
                    }
                }
            };

            List<Pizza> clone = [.. pizzas.Select(p => new Pizza(p))];

            pizzas[0].Toppings.Clear();

            clone[0].Toppings.Should().HaveCount(3);
        }
    }
}
