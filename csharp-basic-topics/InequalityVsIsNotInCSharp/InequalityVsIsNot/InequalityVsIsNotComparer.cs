namespace InequalityVsIsNot
{
    public class InequalityVsIsNotComparer
    {
        private const int _constantSerialNumber = 1000;

        public void SerialNumberComparerUsingNotEqual(Vehicle vehicle)
        {
            if (vehicle.SerialNumber != _constantSerialNumber)
            {
                Console.WriteLine("serial number != 1000");
            }
        }

        public void SerialNumberComparerUsingIsNot(Vehicle vehicle)
        {
            if (vehicle.SerialNumber is not _constantSerialNumber)
            {
                Console.WriteLine("serial number is not 1000");
            }
        }

        public void VehicleIsNotToNull(Vehicle vehicle)
        {
            if (vehicle is not null)
            {
                Console.WriteLine("vehicle is not null");
            }
        }

        public void BoxedSerialNumberComparerUsingNotEqual(Vehicle vehicle)
        {
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber != (object)_constantSerialNumber)
            {
                Console.WriteLine("boxed serial number != 1000");
            }
        }

        public void BoxedSerialNumberComparerUsingIsNot(Vehicle vehicle)
        {
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber is not _constantSerialNumber)
            {
                Console.WriteLine("boxed serial number is not 1000");
            }
        }

        public void BrandComparerUsingNotEqual(Vehicle vehicle)
        {
            if (vehicle.VehicleBrand != Brand.Ford)
            {
                Console.WriteLine("brand != Ford");
            }
        }

        public void BrandComparerUsingIsNot(Vehicle vehicle)
        {
            if (vehicle.VehicleBrand is not Brand.Ford)
            {
                Console.WriteLine("brand is not Ford");
            }
        }

        public void ModelComparerUsingNotEqual(Car car)
        {
            if (car.Model != "Focus")
            {
                Console.WriteLine("model != Focus");
            }
        }

        public void ModelComparerUsingIsNot(Car car)
        {
            if (car.Model is not "Focus")
            {
                Console.WriteLine("model is not Focus");
            }
        }

        public void CarTypeComparerUsingNotEqual(Car car)
        {
            if (car.GetType() != typeof(Vehicle))
            {
                Console.WriteLine("car != Vehicle");
            }
        }

        public void CarTypeComparerUsingIsNot(Car car)
        {
            if (car is not Vehicle)
            {
                Console.WriteLine("car is not Vehicle");
            }
            else
            {
                Console.WriteLine("car is Vehicle");
            }
        }

        public void AnotherModelComparerUsingIsNot(Car car)
        {
            const string a = "Fo";
            const string b = "cus";

            if (car.Model is not $"{a}{b}") 
            { 
                Console.WriteLine("model is not Focus"); 
            } 
        }
    }
}
