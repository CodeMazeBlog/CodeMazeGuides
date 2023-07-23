using BogusNugetPackage;

Console.WriteLine("Initializing data with Bogus...");
DataGenerator.InitBogusData();

Console.WriteLine("-----------------");

Console.WriteLine("Single Employee: ");
Console.WriteLine(DataGenerator.Employees.First());

Console.WriteLine("-----------------");

Console.WriteLine("Multiple Employees: ");
DataGenerator.Employees.ForEach(Console.WriteLine);

Console.WriteLine("-----------------");

Console.WriteLine("DB Seeded Employees: ");
DataGenerator.GetSeededEmployeesFromDb().ForEach(Console.WriteLine);