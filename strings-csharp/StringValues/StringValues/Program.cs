Console.WriteLine("Naive Implementation:");
NaiveImplementation.AddHeader("MyHeader", "value1");
NaiveImplementation.AddHeader("MyHeader", "value2");

Console.WriteLine("Legacy Implementation:");
LegacyImplementation.AddHeader("MyHeader", "value1");
LegacyImplementation.AddHeader("MyHeader", "value2");

Console.WriteLine("StringValues Implementation:");
StringValuesImplementation.AddHeader("MyHeader", "value1");
StringValuesImplementation.AddHeader("MyHeader", "value2");
StringValuesImplementation.DisplayHeaders();