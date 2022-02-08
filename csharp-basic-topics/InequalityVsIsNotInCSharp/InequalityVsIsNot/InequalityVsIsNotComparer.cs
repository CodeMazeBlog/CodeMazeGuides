namespace InequalityVsIsNot
{
    public class InequalityVsIsNotComparer
    {
        public const int _constantSerialNumber = 1001;

        public bool NotEqualSerialNumber(Vehicle vehicle)
        {
            var result = false;
            if (vehicle.SerialNumber != _constantSerialNumber)
            {
                result = true;
            }

            return result;
        }

        public bool IsNotSerialNumber(Vehicle vehicle)
        {
            var result = false;
            if (vehicle.SerialNumber is not _constantSerialNumber)
            {
                result = true;
            }

            return result;
        }

        public bool NotEqualToNull(Vehicle vehicle)
        {
            var result = false;
            if (vehicle != null)
            {
                result = true;
            }

            return result;
        }

        public bool IsNotToNull(Vehicle vehicle)
        {
            var result = false;
            if (vehicle is not null)
            {
                result = true;
            }

            return result;
        }

        public bool NotEqualSerialNumberUsingBoxing(Vehicle vehicle)
        {
            var result = false;
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber != (object)_constantSerialNumber)
            {
                result = true;
            }

            return result;
        }

        public bool IsNotSerialNumberWithBoxing(Vehicle vehicle)
        {
            var result = false;
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber is not _constantSerialNumber)
            {
                result = true;
            }

            return result;
        }

        public bool NotEqualBrand(Vehicle vehicle)
        {
            var result = false;
            if (vehicle.VehicleBrand != Brand.Ford)
            {
                result = true;
            }

            return result;
        }

        public bool IsNotBrand(Vehicle vehicle)
        {
            var result = false;
            if (vehicle.VehicleBrand is not Brand.Ford)
            {
                result = true;
            }

            return result;
        }

        public bool NotEqualModel(Car car)
        {
            var result = false;
            if (car.Model != "Focus")
            {
                result = true;
            }

            return result;
        }

        public bool IsNotModel(Car car)
        {
            var result = false;
            if (car.Model is not "Focus")
            {
                result = true;
            }

            return result;
        }

        public bool NotEqualClass(Car car)
        {
            var result = false;
            if (car.GetType() != typeof(Vehicle))
            {
                result = true;
            }

            return result;
        }

        public bool IsNotClass(Car car)
        {
            var result = false;
            if (car is not Vehicle)
            {
                result = true;
            }

            return result;
        }
    }
}
