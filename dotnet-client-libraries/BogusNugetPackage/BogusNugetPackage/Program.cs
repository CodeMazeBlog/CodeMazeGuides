using BogusNugetPackage;

Console.WriteLine("Initializing data with Bogus...");
DataGenerator.InitBogusEmployeeData();

Console.WriteLine("-----------------");

Console.WriteLine("Single Employee: ");
Console.WriteLine(DataGenerator.GetSingleEmployee());

Console.WriteLine("-----------------");

Console.WriteLine("Multiple Employees: ");
DataGenerator.GetListOfEmployees().ForEach(Console.WriteLine);
