using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NonNullablePropertyWarning;

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
        [ExpectedException(typeof(NullReferenceException))]
        public void WhenDereferencingFirstName_ThenExceptionThrown() => _ = _address?.FirstName.Length;

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
    }
}