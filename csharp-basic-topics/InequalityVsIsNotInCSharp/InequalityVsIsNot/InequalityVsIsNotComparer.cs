namespace InequalityVsIsNot
{
    public class InequalityVsIsNotComparer
    {
        public const int _constantSerialNumber = 1000;

        public void CompareWithNull(Vehicle vehicle)
        {
            if (vehicle != null)
                Console.WriteLine($"vehicle != null");

            if (vehicle is not null)
                Console.WriteLine($"vehicle is not null");
        }

        public void CompareSerialNumberBoxed(Vehicle vehicle)
        {
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber != (object)_constantSerialNumber)
                Console.WriteLine($"boxed serial number != {_constantSerialNumber}");

            if (boxedSerialNumber is not _constantSerialNumber)
                Console.WriteLine($"boxed serial number is not {_constantSerialNumber}");
        }

        public void CompareSerialNumber(Vehicle vehicle)
        {
            if (vehicle.SerialNumber != _constantSerialNumber)
                Console.WriteLine($"serial number != {_constantSerialNumber}");

            if (vehicle.SerialNumber is not _constantSerialNumber)
                Console.WriteLine($"serial number is not {_constantSerialNumber}");
        }

        public void CompareBrand(Vehicle vehicle)
        {
            if (vehicle.VehicleBrand != Brand.Ford)
                Console.WriteLine("vehicle brand != Ford");

            if (vehicle.VehicleBrand is not Brand.Ford)
                Console.WriteLine("vehicle brand is not Ford");
        }

        public void CompareModel(Car car)
        {
            if (car.Model != "Fiesta")
                Console.WriteLine("car model != Focus");

            if (car.Model is not "Fiesta")
                Console.WriteLine("car model is not Focus");
        }

        public void CompareClasses(Car car)
        {
            if (car.GetType() != typeof(Vehicle))
                Console.WriteLine("car type != Vehicle");

            if (car is not Vehicle)
                Console.WriteLine("car type is not Vehicle");
        }
    }
}
