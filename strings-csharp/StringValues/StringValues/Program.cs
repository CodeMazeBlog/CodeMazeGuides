Console.WriteLine("Naive Implementation:");
NaiveImplementation naiveImplementation = new();
naiveImplementation.AddHeader("MyHeader", "value1", "value2", "value3");

Console.WriteLine("Legacy Implementation:");
LegacyImplementation legacyImplementation = new();
legacyImplementation.AddHeader("MyHeader", "value1", "value2", "value3");

var stringValuesImplementation = new StringValuesImplementation();
stringValuesImplementation.DemonstrateStringValues();
stringValuesImplementation.AddHeader("MyHeader", "value1", "value2", "value3");
stringValuesImplementation.DisplayHeaders();