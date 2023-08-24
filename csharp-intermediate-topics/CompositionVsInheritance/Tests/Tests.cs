using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositionVsInheritance.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenBaseClassInstantiated_AllMembersAccesible()
        {
            var house = new House();
            house.Color = "Blue";

            Assert.AreEqual("Blue", house.Color);

            Assert.AreEqual("Building a floor...", house.GetFloor());

            Assert.AreEqual("Building a ceiling...", house.GetCeiling());
        }

        [TestMethod]
        public void WhenDerivedClassInstantiated_AllBaseMethodsAccesible()
        {
            var glassHouse = new GlassHouse();

            Assert.AreEqual("Building a floor...", glassHouse.GetFloor());

            Assert.AreEqual("Building a ceiling...", glassHouse.GetCeiling());
        }

        [TestMethod]
        public void WhenClassInstantiated_AllComponentMethodsAccesible()
        {
            var brickHouse = new BrickHouse();

            Assert.AreEqual("Address", brickHouse.GetAddress());
        }
    }
}