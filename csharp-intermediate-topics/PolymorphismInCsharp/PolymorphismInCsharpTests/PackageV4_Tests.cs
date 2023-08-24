using NUnit.Framework;
using Polymorphism;
using Polymorphism_v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismTest
{
    public class PackageV4_Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenPointingToPremiumExpeditedPackage_TheExpeditedPackageMethodShouldBeCalled()
        {
            Package p1 = new Package("Sender A", "Address A", 10, new DateTime(2021, 12, 1));
            Package p2 = new ExpeditedPackage("Sender B", "Address B", 10, new DateTime(2021, 12, 1));
            Package p3 = new PremiumExpeditedPackage("Sender C", "Address C", 10, new DateTime(2021, 12, 1));

            Assert.AreEqual(p1.GetDeliveryCost(), 30);
            Assert.AreEqual(p1.GetDeliveryDate(), new DateTime(2021, 12, 3));
            Assert.AreEqual(p2.GetDeliveryCost(), 42);
            Assert.AreEqual(p2.GetDeliveryDate(), new DateTime(2021, 12, 2));
            Assert.AreEqual(p3.GetDeliveryCost(), 42);
            Assert.AreEqual(p3.GetDeliveryDate(), new DateTime(2021, 12, 2));
        }

    }
}