using NUnit.Framework;
using Polymorphism;
using Polymorphism_v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismTest
{
    public class PackageV1_Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenPointingToExpeditedPackage_TheBasePackageMethodShouldBeCalled()
        {
            DateTime now = new DateTime(2021, 12, 1);
            ExpeditedPackage ep = new ExpeditedPackage("Sender B", "Address B", 10, now);
            Package p = ep;

            Assert.AreEqual(p.GetDeliveryCost(), 30);
            Assert.AreEqual(p.GetDeliveryDate(), now.AddDays(2));
        }
    }
}