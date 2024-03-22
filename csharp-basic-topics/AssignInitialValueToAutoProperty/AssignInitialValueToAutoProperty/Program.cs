using AssignInitialValueToAutoProperty;
using System.ComponentModel;

var hondaCars = new HondaCars();
Console.WriteLine("===========Inline initialization==========");
Console.WriteLine($"Car Color: {hondaCars.Color}");
Console.WriteLine($"Car Cost: {hondaCars.Cost}");

var toyotaCars = new ToyotaCars();
Console.WriteLine("======Constructor initialization==========");
Console.WriteLine($"Car Color: {toyotaCars.Color}");
Console.WriteLine($"Car Cost: {toyotaCars.Cost}");

var kiaCars = new KiaCars();
Console.WriteLine("==========Using Field Initialization===========");
Console.WriteLine($"Car Color: {kiaCars.Color}");
Console.WriteLine($"Car Cost: {kiaCars.Cost}");