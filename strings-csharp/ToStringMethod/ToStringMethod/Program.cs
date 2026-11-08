using ToStringMethod;

var person = new Person("John Doe", 30, "Software Developer");
Console.WriteLine(person.ToString());

var car = new Car("Tesla", "Model S", 100000M, new DateTime(2022, 12, 2, 17, 10, 56));
Console.WriteLine(car.ToString("en-US"));
Console.WriteLine(car.ToString("en-US", "dd-MMM-yyyy"));

var personRecord = new PersonRecord("John Doe", 30, "Software Developer");
Console.WriteLine(personRecord);
