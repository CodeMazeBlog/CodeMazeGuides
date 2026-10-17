using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NonNullablePropertyWarning;
using HelperAddress = NonNullablePropertyWarning.HelperMethod.Address;

namespace Tests
{
    [TestClass]
    public class NonNullablePropertyWarningUnitTest
    {
        private Address? _address;

        [TestInitialize]
        public void Setup()
        {
            _address = new Address() { Area = "Test Area"};
        }

        [TestMethod]
        public void WhenDereferencingFirstName_ThenExceptionThrown() =>
            Assert.ThrowsExactly<NullReferenceException>(() => _ = _address!.FirstName.Length);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenFirstNameNull() => Assert.IsNull(_address?.FirstName);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenMiddleNameNull() => Assert.IsNull(_address?.MiddleName);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenLastNameNull() => Assert.IsNull(_address?.LastName);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenCityNotNull() => Assert.AreEqual("Default City", _address?.City);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenCountryNull() => Assert.IsNull(_address?.Country);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenPostalCodeNull() => Assert.IsNull(_address?.PostalCode);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenRegionNull() => Assert.IsNull(_address?.Region);

        [TestMethod]
        public void WhenInstantiatingAddress_ThenTownEmpty() => Assert.AreEqual(string.Empty, _address?.Town);

        [TestMethod]
        public void WhenInstantiatingHelperAddressWithoutCity_ThenCityDefault() =>
            Assert.AreEqual("Default City", new HelperAddress().City);

        [TestMethod]
        public void WhenInstantiatingHelperAddressWithCity_ThenCitySet() =>
            Assert.AreEqual("Belgrade", new HelperAddress("Belgrade").City);
    }
}