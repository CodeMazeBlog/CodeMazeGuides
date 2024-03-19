using AutoAssignProperty;
using System.ComponentModel;

namespace Tests
{
    [TestClass]
    public class AutoPropertyAssignTest
    {
        [TestMethod]
        public void GivenInitialValueWithInlineInitialization_WhenPropertyAccessed_ThenExpectAssignedValue()
        {
            var hondaCars = new HondaCars();

            Assert.AreEqual("White", hondaCars.Color);
            Assert.AreEqual(500000.00m, hondaCars.Cost);
        }

        [TestMethod]
        public void GivenInitialValueWithConstructorInitialization_WhenPropertyAccessed_ThenExpectAssignedValue()
        {
            var toyotaCars = new ToyotaCars();

            Assert.AreEqual("Black", toyotaCars.Color);
            Assert.AreEqual(400000.00m, toyotaCars.Cost);
        }

        [TestMethod]
        public void GivenInitialValueWithPropertySetter_WhenPropertyAccessed_ThenExpectAssignedValue()
        {
            var kiaCars = new KiaCars();

            Assert.AreEqual("Silver", kiaCars.Color);
            Assert.AreEqual(600000.00m, kiaCars.Cost);
        }
        [TestMethod]
        public void GivenInitialValueWithDefaultValueAttribute_WhenPropertyAccessed_ThenExpectAssignedValue()
        {
            var fordCars = new FordCars();
            DefaultValueAttribute attribute = (DefaultValueAttribute)TypeDescriptor.GetProperties(fordCars)["Color"].Attributes[typeof(DefaultValueAttribute)];
            string? defaultValue = (string)(attribute.Value);

            Assert.AreEqual("Blue", defaultValue);
        }
    }
}