using System.Collections.Concurrent;
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

        [TestMethod]
        public void GivenExistingTopping_WhenAddToppingIfMissing_ThenValueIsUnchanged()
        {
            var dictionary = new ToppingsDictionary();

            dictionary.AddToppingIfMissing("pepperoni", 100);
            dictionary.AddToppingIfMissing("mushroom", 2);

            Assert.AreEqual(4, dictionary.Toppings["pepperoni"]);
            Assert.AreEqual(2, dictionary.Toppings["mushroom"]);
        }

        [TestMethod]
        public void GivenNewAndExistingToppings_WhenAddToppingsByRef_ThenBothAreUpdated()
        {
            var dictionary = new ToppingsDictionary();

            dictionary.AddToppingsByRef("mushroom", 5);
            dictionary.AddToppingsByRef("pepperoni", 4);

            Assert.AreEqual(5, dictionary.Toppings["mushroom"]);
            Assert.AreEqual(8, dictionary.Toppings["pepperoni"]);
        }

        [TestMethod]
        public void GivenConcurrentDictionary_WhenAddOrUpdate_ThenAddsThenUpdates()
        {
            var toppings = new ConcurrentDictionary<string, int>();

            var first = toppings.AddOrUpdate("pepperoni", 4, (_, currentAmount) => currentAmount + 4);
            var second = toppings.AddOrUpdate("pepperoni", 4, (_, currentAmount) => currentAmount + 4);

            Assert.AreEqual(4, first);
            Assert.AreEqual(8, second);
        }
    }
}