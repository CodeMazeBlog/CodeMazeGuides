using DifferencesRecordStructAndRecordClassInCSharp;

var recordClassDefaultValue = DefaultValues.GetRecordClassDefaultValue();
var recordStructDefaultValue = DefaultValues.GetRecordStructDefaultValue();
Console.WriteLine($"Record class default value is {(recordClassDefaultValue == null ? "null" : recordClassDefaultValue)}");
Console.WriteLine($"Record struct default value is {(recordStructDefaultValue == null ? "null" : recordStructDefaultValue)}");


