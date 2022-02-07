using InequalityVsIsNot;
using Xunit;

namespace Tests
{
    public class InequalityVsIsNotTest
    {
        readonly InequalityVsIsNotComparer _comparer;
        readonly Vehicle _vehicle;
        readonly Car _car;
        public InequalityVsIsNotTest()
        {
            _comparer = new InequalityVsIsNotComparer();

            _vehicle = new Vehicle();
            _vehicle.SerialNumber = 1000;
            _vehicle.VehicleBrand = Brand.Toyota;

            _car = new Car();
            _car.Model = "Fiesta";
            _car.VehicleBrand = Brand.Ford;
        }

        [Fact]
        public void WhenNotToNullObject_ThenNotEqualNull()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.NotEqualToNull(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenIsNotNUllObject_ThenIsNotNull()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.IsNotToNull(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenSerialNumberIsBoxedAndNotEqualToConstant_ThenTheyAreDifferent()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.NotEqualSerialNumberUsingBoxing(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenSerialNumberIsBoxedAndIsNotConstant_ThenTheyAreEqual()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.IsNotSerialNumberWithBoxing(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenSerialNumberNotEqualToConstant_ThenTheyAreDifferent()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.NotEqualSerialNumber(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenSerialNumberIsNotConstant_ThenTheyAreDifferent()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.IsNotSerialNumber(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenBrandNotEqualToConstant_ThenTheyAreDifferent()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.NotEqualBrand(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenBrandIsNotConstant_ThenTheyAreDifferent()
        {
            Vehicle vehicle = new Vehicle();
            bool result = _comparer.IsNotBrand(vehicle);

            Assert.True(result);
        }

        [Fact]
        public void WhenModelNotEqualToConstant_ThenTheyAreDifferent()
        {
            Car car = new Car();
            bool result = _comparer.NotEqualModel(car);

            Assert.True(result);
        }

        [Fact]
        public void WhenModelIsNotConstant_ThenTheyAreDifferent()
        {
            Car car = new Car();
            bool result = _comparer.IsNotModel(car);

            Assert.True(result);
        }

        [Fact]
        public void WhenCarNotEqualToVehicle_ThenTheyAreDifferent()
        {
            Car car = new Car();
            bool result = _comparer.NotEqualClass(car);

            Assert.True(result);
        }

        [Fact]
        public void WhenCarIsNotVehicle_ThenTheyAreEqual()
        {
            Car car = new Car();
            bool result = _comparer.IsNotClass(car);

            Assert.True(!result);
        }

    }
}