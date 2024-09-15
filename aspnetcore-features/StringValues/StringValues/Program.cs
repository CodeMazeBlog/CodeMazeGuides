NaiveImplementation naiveImplementation = new();
naiveImplementation.AddHeader("MyHeader", "value1", "value2", "value3");

LegacyImplementation legacyImplementation = new();
legacyImplementation.AddHeader("MyHeader", "value1", "value2", "value3");

var stringValuesImplementation = new StringValuesImplementation();
stringValuesImplementation.DemonstrateStringValues();
stringValuesImplementation.AddHeader("MyHeader", "value1", "value2", "value3");
stringValuesImplementation.DisplayHeaders();