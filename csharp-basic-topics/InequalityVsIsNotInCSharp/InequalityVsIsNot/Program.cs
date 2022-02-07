using InequalityVsIsNot;


InequalityVsIsNotComparer comparer = new InequalityVsIsNotComparer();

Vehicle vehicle = new Vehicle();
vehicle.SerialNumber = 1001;
vehicle.VehicleBrand = Brand.Toyota;

Car car = new Car();
car.Model = "Fiesta";
car.VehicleBrand = Brand.Ford;
bool result = false;
result = comparer.NotEqualSerialNumber(vehicle);
if (result)
{
    Console.WriteLine("serial number != 1000");
}

result = comparer.IsNotSerialNumber(vehicle);
if (result)
{
    Console.WriteLine("serial number is not 1000");
}

result = comparer.NotEqualToNull(vehicle);
if (result)
{
    Console.WriteLine("vehicle != null");
}

result = comparer.IsNotToNull(vehicle);
if (result)
{
    Console.WriteLine("vehicle is not null");
}

result = comparer.NotEqualSerialNumberUsingBoxing(vehicle);
if (result)
{
    Console.WriteLine("boxed serial number != 1000");
}

result = comparer.IsNotSerialNumberWithBoxing(vehicle);
if (result)
{
    Console.WriteLine("boxed serial number is not 1000");
}

result = comparer.NotEqualBrand(vehicle);
if (result)
{
    Console.WriteLine("brand != Ford");
}

result = comparer.IsNotBrand(vehicle);
if (result)
{
    Console.WriteLine("brand is not Ford");
}

result = comparer.NotEqualModel(car);
if (result)
{
    Console.WriteLine("model != Focus");
}

result = comparer.IsNotModel(car);
if (result)
{
    Console.WriteLine("model is not Focus");
}

result = comparer.NotEqualClass(car);
if (result)
{
    Console.WriteLine("car != Vehicle");
}

result = comparer.IsNotClass(car);
if (result)
{
    Console.WriteLine("car is not Vehicle");
}
else
{
    Console.WriteLine("car is Vehicle");
}


