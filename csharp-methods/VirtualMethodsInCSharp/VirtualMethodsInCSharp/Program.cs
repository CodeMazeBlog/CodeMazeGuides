using VirtualMethodsInCSharp;

var shape = new Shape();
var circle = new Circle() { Radius = 2 };
var rectangle = new Rectangle() { Height = 2, Width = 3 };

Console.WriteLine($"Shape area: {shape.CalculateArea()}"); // Shape area: 0
Console.WriteLine($"Circle area: {circle.CalculateArea()}"); // Circle area: 12,566370614359172
Console.WriteLine($"Rectangle area: {rectangle.CalculateArea()}"); // Rectangle area: 6

Console.WriteLine($"Shape type: {shape.GetShapeType()}"); // Shape type: This is a generic shape
Console.WriteLine($"Circle type: {circle.GetShapeType()}"); // Circle type: This is a generic shape
Console.WriteLine($"Rectangle type: {rectangle.GetShapeType()}"); // Rectangle type: This is a rectangle

Shape circleAsShape = new Circle() { Radius = 2 };
Console.WriteLine($"Shape draw: {shape.Draw()}"); // Shape draw: Drawing a generic shape
Console.WriteLine($"Circle draw: {circleAsShape.Draw()}"); // Circle draw: Drawing a generic shape
Console.WriteLine($"Rectangle draw: {rectangle.Draw()}"); // Rectangle draw: Drawing a rectangle