namespace ReadOnlyModifierInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(5.0);
            //circle._radius = 10.0; //Throws compiler error
            var circumference = circle.GetCircumference();
            Console.WriteLine($"Circumference: {circumference}");

            var point = new Point(2, 3);
            Console.WriteLine($"Coordinates: X - {point.X}, Y - {point.Y}");

            //point.X = 6; //Throws compiler error
            //point.Y = 10; //Throws compiler error

            var person = new Person("Jack");
            Console.WriteLine($"Name: {person.Name}");

            //person.Name = "Emily"; //Throws compiler error

            person.ChangeName("Emily");
            Console.WriteLine($"Changed Name: {person.Name}");
        }
    }
}