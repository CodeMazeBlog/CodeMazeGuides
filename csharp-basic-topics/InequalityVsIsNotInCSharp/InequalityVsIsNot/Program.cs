using InequalityVsIsNot;

var comparer = new InequalityVsIsNotComparer();

var vehicle = new Vehicle()
{
    SerialNumber = 1001,
    VehicleBrand = Brand.Toyota
};

var car = new Car()
{
    Model = "Fiesta",
    VehicleBrand = Brand.Ford
};

comparer.SerialNumberComparerUsingNotEqual(vehicle);

comparer.SerialNumberComparerUsingIsNot(vehicle);

comparer.VehicleNotEqualToNull(vehicle);

comparer.VehicleIsNotToNull(vehicle);

comparer.BoxedSerialNumberComparerUsingNotEqual(vehicle);

comparer.BoxedSerialNumberComparerUsingIsNot(vehicle);

comparer.BrandComparerUsingNotEqual(vehicle);

comparer.BrandComparerUsingIsNot(vehicle);

comparer.ModelComparerUsingNotEqual(car);

comparer.ModelComparerUsingIsNot(car);

comparer.AnotherModelComparerUsingIsNot(car);

comparer.CarTypeComparerUsingNotEqual(car);

comparer.CarTypeComparerUsingIsNot(car);
