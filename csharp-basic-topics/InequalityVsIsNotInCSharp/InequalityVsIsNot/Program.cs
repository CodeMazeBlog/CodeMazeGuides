using InequalityVsIsNot;

var comparer = new InequalityVsIsNotComparer();

var vehicle = new Vehicle();
vehicle.SerialNumber = 1001;
vehicle.VehicleBrand = Brand.Toyota;

var car = new Car();
car.Model = "Fiesta";
car.VehicleBrand = Brand.Ford;

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

comparer.CarTypeComparerUsingNotEqual(car);

comparer.CarTypeComparerUsingIsNot(car);
