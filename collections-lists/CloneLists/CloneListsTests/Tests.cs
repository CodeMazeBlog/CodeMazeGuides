using CloneLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloneListsTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void verifylistwascloned_usingToListExample()
        {
            List<string> carList = new List<string>() { "Porsche", "Corvette", "Bugati" };
            ToListExample tle = new ToListExample();
            List<string> clonedCarList = tle.RunToListExample(carList);

            Assert.AreEqual(carList[0], clonedCarList[0]);
            Assert.AreEqual(carList[1], clonedCarList[1]);
            Assert.AreEqual(carList[2], clonedCarList[2]);
        }

        [TestMethod]
        public void verifylistwascloned_usingExtensionExample()
        {
            ExtensionMethodExample eme = new ExtensionMethodExample();
            var restaurantList = new List<Restaurant>();
            restaurantList.Add(new Restaurant { Name = "Thai Angel", Cuisine = "Thai" });
            restaurantList.Add(new Restaurant { Name = "Cafe Havana", Cuisine = "Cuban" });
            eme.RunExtensionMethodExample(restaurantList);

            Assert.AreEqual(restaurantList[0].Name, eme.clonedRestaurantList[0].Name);
            Assert.AreEqual(restaurantList[0].Cuisine, eme.clonedRestaurantList[0].Cuisine);
            Assert.AreEqual(restaurantList[1].Name, eme.clonedRestaurantList[1].Name);
            Assert.AreEqual(restaurantList[1].Cuisine, eme.clonedRestaurantList[1].Cuisine);
        }

        [TestMethod]
        public void verifylistwascloned_usingBinaryFormatterExample()
        {
            BinaryFormatterExample bfe = new BinaryFormatterExample();
            var resortList = new List<Resort>();
            resortList.Add(new Resort { Name = "Segarden", Location = "Jamaica" });
            resortList.Add(new Resort { Name = "Caribe Hilton", Location = "Puerto Rico" });
            bfe.RunBinaryFormatterExample(resortList);

            Assert.AreEqual(resortList[0].Name, bfe.clonedResortList[0].Name);
            Assert.AreEqual(resortList[0].Location, bfe.clonedResortList[0].Location);
            Assert.AreEqual(resortList[1].Name, bfe.clonedResortList[1].Name);
            Assert.AreEqual(resortList[1].Location, bfe.clonedResortList[1].Location);
        }

        [TestMethod]
        public void verifylistwascloned_usingCopyToExample()
        {
            CopyToMethodExample cme = new CopyToMethodExample();
            var fallList = new List<string>() { "pumpkins", "halloween" };
            string[] fallListCloned = cme.RunCopyToMethodExample(fallList);

            Assert.AreEqual(fallList[0], fallListCloned[0]);
            Assert.AreEqual(fallList[1], fallListCloned[1]);

        }
    }
}