using InequalityVsIsNot;

var comparer = new InequalityVsIsNotComparer();

var vehicle = new Vehicle();
vehicle.SerialNumber = 1001;
vehicle.VehicleBrand = Brand.Toyota;

var car = new Car();
car.Model = "Fiesta";
car.VehicleBrand = Brand.Ford;

comparer.SerialNumberComparationWithNotEqual(vehicle);

comparer.SerialNumberComparationWithIsNot(vehicle);

comparer.VehicleNotEqualToNull(vehicle);

comparer.VehicleIsNotToNull(vehicle);

comparer.BoxedSerialNumberComparationWithNotEqual(vehicle);

comparer.BoxedSerialNumberComparationWithIsNot(vehicle);

comparer.BrandComparationWithNotEqual(vehicle);

comparer.BrandComparationWithIsNot(vehicle);

comparer.ModelComparationWithNotEqual(car);

comparer.ModelComparationWithIsNot(car);

comparer.CarTypeComparationWithNotEqual(car);

comparer.CarTypeComparationWithIsNot(car);
