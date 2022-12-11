using ToStringMethod;

var person = new Person("John Doe", 30, "Software Developer");
person.ToString();

var person2 = new Person();
person2.ToString();


var car = new Car("Tesla", "Model S", 100000M, DateTime.Now);
car.ToString("en-US");
car.ToString("en-US", "dd-MMM-yyyy");

var car2 = new Car();
car2.ToString("en-GB");
car2.ToString("en-GB", "dd-MMM-yyyy");
