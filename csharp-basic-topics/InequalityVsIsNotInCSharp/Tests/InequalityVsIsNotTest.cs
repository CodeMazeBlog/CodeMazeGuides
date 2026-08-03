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
            _comparer.BoxedSerialNumberComparerUsingNotEqual(_vehicle);
            var expected = string.Format($"boxed serial number != 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberIsBoxedAndNotConstant_ThenTheyAreEqual()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BoxedSerialNumberComparerUsingIsNot(_vehicle);
            var expected = string.Format($"boxed serial number is not 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.SerialNumberComparerUsingNotEqual(_vehicle);
            var expected = string.Format($"serial number != 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenSerialNumberIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.SerialNumberComparerUsingIsNot(_vehicle);
            var expected = string.Format($"serial number is not 1000{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenBrandNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BrandComparerUsingNotEqual(_vehicle);
            var expected = string.Format($"brand != Ford{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenBrandIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.BrandComparerUsingIsNot(_vehicle);
            var expected = string.Format($"brand is not Ford{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelNotEqualToConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.ModelComparerUsingNotEqual(_car);
            var expected = string.Format($"model != Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelIsNotConstant_ThenTheyAreDifferent()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.ModelComparerUsingIsNot(_car);
            var expected = string.Format($"model is not Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenModelIsNotCombinationOfTwoConstant_ThenTheyAreDifferent()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.AnotherModelComparerUsingIsNot(car);
            var expected = string.Format($"model is not Focus{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenCarNotEqualToVehicle_ThenTheyAreDifferent()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.CarTypeComparerUsingNotEqual(car);
            var expected = string.Format($"car != Vehicle{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenCarIsNotVehicle_ThenTheyAreEqual()
        {
            var car = new Car();
            using var sw = new StringWriter();
            Console.SetOut(sw);
            _comparer.CarTypeComparerUsingIsNot(car);
            var expected = string.Format($"car is Vehicle{Environment.NewLine}");

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void WhenEqualOperatorIsOverloaded_ThenCorrectOutput()
        {
            var input1 = new Car()
            {
                SerialNumber = 1001,
                VehicleBrand = Brand.Toyota
            };
            var input2 = new Car()
            {
                SerialNumber = 1002,
                VehicleBrand = Brand.Toyota
            };
            var expected = true;
            var actual = input1 == input2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenNotEqualOperatorIsOverloaded_ThenCorrectOutput()
        {
            var input1 = new Car()
            {
                SerialNumber = 1001,
                VehicleBrand = Brand.Toyota
            };

            var expected = false;
            var actual = input1 != null;

            Assert.Equal(expected, actual);
        }

    }
}