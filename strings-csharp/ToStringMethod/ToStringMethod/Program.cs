using ToStringMethod;

var person = new Person("John Doe", 30, "Software Developer");
person.ToString();

var car = new Car("Tesla", "Model S", 100000M, DateTime.Now);
car.ToString("en-US");
car.ToString("en-US", "dd-MMM-yyyy");
