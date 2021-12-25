using NUnit.Framework;
using Polymorphism;
using Polymorphism_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismTest
{
    public class PackageV3_Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenPointingToExpeditedPackage_TheExpeditedPackageMethodShouldBeCalled()
        {
            DateTime now = DateTime.Now;
            ExpeditedPackage ep = new ExpeditedPackage("Sender B", "Address B", 10, now);
            Package p = ep;

            Assert.AreEqual(p.GetDeliveryCost(), 42);
            Assert.AreEqual(p.GetDeliveryDate(), now.AddDays(1));
        }
    }
}