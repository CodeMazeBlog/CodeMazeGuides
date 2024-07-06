Console.WriteLine("Naive Implementation:");
NaiveImplementation naiveImplementation = new();
naiveImplementation.AddHeader("MyHeader", "value1");
naiveImplementation.AddHeader("MyHeader", "value2");

Console.WriteLine("Legacy Implementation:");
LegacyImplementation legacyImplementation = new();
legacyImplementation.AddHeader("MyHeader", "value1");
legacyImplementation.AddHeader("MyHeader", "value2");

Console.WriteLine("StringValues Implementation:");
StringValuesImplementation stringValuesImplementation = new();
stringValuesImplementation.AddHeader("MyHeader", "value1");
stringValuesImplementation.AddHeader("MyHeader", "value2");
stringValuesImplementation.DisplayHeaders();