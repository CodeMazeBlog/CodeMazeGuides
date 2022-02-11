using InequalityVsIsNot;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    public class InequalityVsIsNotTest
    {
        private readonly InequalityVsIsNotComparer _comparer;
        private readonly Vehicle _vehicle;
        private readonly Car _car;
        public InequalityVsIsNotTest()
        {
            _comparer = new InequalityVsIsNotComparer();

            _vehicle = new Vehicle();
            _vehicle.SerialNumber = 1001;
            _vehicle.VehicleBrand = Brand.Toyota;

            _car = new Car();
            _car.Model = "Fiesta";
            _car.VehicleBrand = Brand.Ford;
        }

        [Fact]
        public void WhenNotEqualToNullObject_ThenNotEqualNull()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.VehicleNotEqualToNull(_vehicle);
            var expected = string.Format($"vehicle != null{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenIsNotNullObject_ThenIsNotNull()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.VehicleIsNotToNull(_vehicle);
            var expected = string.Format($"vehicle is not null{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberIsBoxedAndNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BoxedSerialNumberComparationWithNotEqual(_vehicle);
            var expected = string.Format($"boxed serial number != 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberIsBoxedAndNotConstant_ThenTheyAreEqual()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BoxedSerialNumberComparationWithIsNot(_vehicle);
            var expected = string.Format($"boxed serial number is not 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.SerialNumberComparationWithNotEqual(_vehicle);
            var expected = string.Format($"serial number != 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.SerialNumberComparationWithIsNot(_vehicle);
            var expected = string.Format($"serial number is not 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenBrandNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BrandComparationWithNotEqual(_vehicle);
            var expected = string.Format($"brand != Ford{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenBrandIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BrandComparationWithIsNot(_vehicle);
            var expected = string.Format($"brand is not Ford{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.ModelComparationWithNotEqual(_car);
            var expected = string.Format($"model != Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.ModelComparationWithIsNot(_car);
            var expected = string.Format($"model is not Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelIsNotCombinationOfTwoConstant_ThenTheyAreDifferent()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.AnotherModelComparationWithIsNot(car);
            var expected = string.Format($"model is not Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenCarNotEqualToVehicle_ThenTheyAreDifferent()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.CarTypeComparationWithNotEqual(car);
            var expected = string.Format($"car != Vehicle{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenCarIsNotVehicle_ThenTheyAreEqual()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.CarTypeComparationWithIsNot(car);
            var expected = string.Format($"car is Vehicle{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }
    }
}