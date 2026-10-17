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

var playlist = new Playlist();
playlist.Add("Bohemian Rhapsody");
playlist.Add("Hotel California");
Console.WriteLine($"Songs: {playlist.Count}");

var tally = new Tally();
tally.Count();
tally.Count();
Console.WriteLine($"Total: {tally.Total}");

var counter = new Counter();
counter.Increment();
counter.Increment();
Console.WriteLine(counter.Describe());

var book = new Book { Title = "Dune" };
Console.WriteLine($"Title: {book.Title}");

//book.Title = "Emma"; //Throws compiler error
