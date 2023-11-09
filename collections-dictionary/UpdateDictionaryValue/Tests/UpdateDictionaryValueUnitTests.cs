using UpdateDictionaryValue;

namespace Tests
{
    [TestClass]
    public class UpdateDictionaryValueUnitTests
    {
        [TestMethod]
        public void GivenUpdatingExistingToppingValue_ThenExistingToppingIsUpdated()
        {
            var dictionary = new ToppingsDictionary();

            var pepperoniTotal = dictionary.Toppings["pepperoni"];
            var meatballTotal = dictionary.Toppings["meatball"];
            var oliveTotal = dictionary.Toppings["olive"];

            dictionary.AddToppings("pepperoni", 1);
            dictionary.AddToppings("meatball", 2);
            dictionary.AddToppings("olive", 3);

            Assert.AreEqual(pepperoniTotal + 1, dictionary.Toppings["pepperoni"]);
            Assert.AreEqual(meatballTotal + 2, dictionary.Toppings["meatball"]);
            Assert.AreEqual(oliveTotal + 3, dictionary.Toppings["olive"]);
        }

        [TestMethod]
        public void GivenUpdatingNewToppingValue_ThenNewToppingIsAdded()
        {
            var dictionary = new ToppingsDictionary();

            var pepperoniTotal = dictionary.Toppings["pepperoni"];

            // Shouldn't throw an exception
            dictionary.AddToppings("mushroom", 12);

            Assert.AreEqual(12, dictionary.Toppings["mushroom"]);
        }
    }
}