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
    public class PackageV2_Tests
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

        [Test]
        public void WhenPointingToInternationalPackage_TheInternationalPackageMethodShouldBeCalled()
        {
            DateTime now = DateTime.Now;
            Package p = new InternationalPackage("Sender B", "Address B", 10, now, "US");

            Assert.AreEqual(p.GetDeliveryCost(), 63);
            Assert.AreEqual(p.GetDeliveryDate(), now.AddDays(3));
        }

        [Test]
        public void WhenAddingMultiplePackagesToCourierOffice_TheCorrectMethodsAreCalled()
        {
            CourierBranch Branch1 = new CourierBranch("Branch 1", "12 Main str.");
            Branch1.AddPackage(new Package("Sender A", "Address A", 10, new DateTime(2021, 12, 1)));
            Branch1.AddPackage(new ExpeditedPackage("Sender B", "Address B", 10, new DateTime(2021, 12, 1)));
            Branch1.AddPackage(new InternationalPackage("Sender C", "Address C", 10, new DateTime(2021, 12, 1), "US"));

            Assert.AreEqual(Branch1.packages.Count, 3);
            Assert.AreEqual(Branch1.packages[0].GetDeliveryCost(), 30);
            Assert.AreEqual(Branch1.packages[0].GetDeliveryDate(), new DateTime(2021, 12, 3));

            Assert.AreEqual(Branch1.packages[1].GetDeliveryCost(), 42);
            Assert.AreEqual(Branch1.packages[1].GetDeliveryDate(), new DateTime(2021, 12, 2));

            Assert.AreEqual(Branch1.packages[2].GetDeliveryCost(), 63);
            Assert.AreEqual(Branch1.packages[2].GetDeliveryDate(), new DateTime(2021, 12, 4));
        }
    }
}