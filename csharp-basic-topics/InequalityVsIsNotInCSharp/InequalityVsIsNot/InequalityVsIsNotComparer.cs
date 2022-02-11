namespace InequalityVsIsNot
{
    public class InequalityVsIsNotComparer
    {
        private const int _constantSerialNumber = 1000;

        public void SerialNumberComparationWithNotEqual(Vehicle vehicle)
        {
            if (vehicle.SerialNumber != _constantSerialNumber)
            {
                Console.WriteLine("serial number != 1000");
            }
        }

        public void SerialNumberComparationWithIsNot(Vehicle vehicle)
        {
            if (vehicle.SerialNumber is not _constantSerialNumber)
            {
                Console.WriteLine("serial number is not 1000");
            }
        }

        public void VehicleNotEqualToNull(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                Console.WriteLine("vehicle != null");
            }
        }

        public void VehicleIsNotToNull(Vehicle vehicle)
        {
            if (vehicle is not null)
            {
                Console.WriteLine("vehicle is not null");
            }
        }

        public void BoxedSerialNumberComparationWithNotEqual(Vehicle vehicle)
        {
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber != (object)_constantSerialNumber)
            {
                Console.WriteLine("boxed serial number != 1000");
            }
        }

        public void BoxedSerialNumberComparationWithIsNot(Vehicle vehicle)
        {
            object boxedSerialNumber = vehicle.SerialNumber;

            if (boxedSerialNumber is not _constantSerialNumber)
            {
                Console.WriteLine("boxed serial number is not 1000");
            }
        }

        public void BrandComparationWithNotEqual(Vehicle vehicle)
        {
            if (vehicle.VehicleBrand != Brand.Ford)
            {
                Console.WriteLine("brand != Ford");
            }
        }

        public void BrandComparationWithIsNot(Vehicle vehicle)
        {
            if (vehicle.VehicleBrand is not Brand.Ford)
            {
                Console.WriteLine("brand is not Ford");
            }
        }

        public void ModelComparationWithNotEqual(Car car)
        {
            if (car.Model != "Focus")
            {
                Console.WriteLine("model != Focus");
            }
        }

        public void ModelComparationWithIsNot(Car car)
        {
            if (car.Model is not "Focus")
            {
                Console.WriteLine("model is not Focus");
            }
        }

        public void CarTypeComparationWithNotEqual(Car car)
        {
            if (car.GetType() != typeof(Vehicle))
            {
                Console.WriteLine("car != Vehicle");
            }
        }

        public void CarTypeComparationWithIsNot(Car car)
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

        public void AnotherModelComparationWithIsNot(Car car)
        {
            const string a = "string b";
            const string b = "string b";

            if (car.Model is not $"{a} {b}") 
            { 
                Console.WriteLine("model is not Focus"); 
            } 
        }
    }
}
