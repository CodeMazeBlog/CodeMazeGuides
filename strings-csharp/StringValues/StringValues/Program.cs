Console.WriteLine("Naive Implementation:");
var naive = new NaiveImplementation();
naive.AddHeader("MyHeader", "value1");
naive.AddHeader("MyHeader", "value2");

Console.WriteLine("Legacy Implementation:");
var legacy = new LegacyImplementation();
legacy.AddHeader("MyHeader", "value1");
legacy.AddHeader("MyHeader", "value2");

Console.WriteLine("StringValues Implementation:");
var stringValues = new StringValuesImplementation();
stringValues.AddHeader("MyHeader", "value1");
stringValues.AddHeader("MyHeader", "value2");
stringValues.DisplayHeaders();