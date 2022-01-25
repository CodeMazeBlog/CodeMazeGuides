using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompositionVsInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CompositionVsInheritance.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenBaseClassInstantiated_AllMembersAccesible()
        {
            var house = new House();

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