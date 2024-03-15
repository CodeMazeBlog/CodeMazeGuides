using ReadOnlyModifierInCSharp;

var circle = new Circle(5.0);
var circumference = circle.GetCircumference();
Console.WriteLine($"Circumference: {circumference}");

var point = new Point(2, 3);
Console.WriteLine($"Coordinates: X - {point.X}, Y - {point.Y}");
var otherPoint = new Point(1, 4);
Console.WriteLine($"Coordinates: X - {otherPoint.X}, Y - {otherPoint.Y}");

//point.X = 6; //Throws compiler error
//point.Y = 10; //Throws compiler error

var person = new Person("Jack", 21);
Console.WriteLine($"Name: {person.Name}");

//person.Name = "Emily"; //Throws compiler error

person.ChangeName("Emily");
Console.WriteLine($"Changed Name: {person.Name}");