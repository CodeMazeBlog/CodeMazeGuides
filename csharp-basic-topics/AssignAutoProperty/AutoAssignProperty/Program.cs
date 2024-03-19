// See https://aka.ms/new-console-template for more information
using AutoAssignProperty;
using System.ComponentModel;

HondaCars hondaCars = new HondaCars();
Console.Write("=============Inline initialization==================\n");
Console.WriteLine($"Car Color: {hondaCars.Color}");
Console.WriteLine($"Car Cost:  {hondaCars.Cost}");

ToyotaCars toyotaCars = new ToyotaCars();
Console.Write("=============Constructor initialization==================\n");
Console.WriteLine($"Car Color:{toyotaCars.Color}");
Console.WriteLine($"Car Cost: {toyotaCars.Cost}");

KiaCars kiaCars = new KiaCars();
Console.Write("=============Using Property Setter==================\n");
Console.WriteLine($"Car Color: {kiaCars.Color}");
Console.WriteLine($"Car Cost: {kiaCars.Cost}");

FordCars fordCars = new FordCars();
Console.Write("=============Default value attribute==================\n");
DefaultValueAttribute attribute = (DefaultValueAttribute)TypeDescriptor.GetProperties(fordCars)["Color"].Attributes[typeof(DefaultValueAttribute)];
string? defaultValue = (string)(attribute.Value);
Console.WriteLine($"Default Car Color: {defaultValue}");
Console.WriteLine($"Car Color: {fordCars.Color}");
Console.ReadLine();