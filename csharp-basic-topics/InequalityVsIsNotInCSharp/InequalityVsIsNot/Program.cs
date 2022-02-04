using InequalityVsIsNot;


InequalityVsIsNotComparer comparer = new InequalityVsIsNotComparer();

Vehicle vehicle = new Vehicle();
vehicle.SerialNumber = 1000;
vehicle.VehicleBrand = Brand.Toyota;

Car car = new Car();
car.Model = "Fiesta";
car.VehicleBrand = Brand.Ford;

comparer.CompareSerialNumber(vehicle);
comparer.CompareSerialNumberBoxed(vehicle);
comparer.CompareBrand(vehicle);
comparer.CompareModel(car);
comparer.CompareClasses(car);


