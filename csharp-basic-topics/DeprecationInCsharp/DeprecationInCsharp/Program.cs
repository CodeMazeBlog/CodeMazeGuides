using DeprecationInCsharp;

var deprecatedMethodResult = DateUtils.GetCurrentYearV1();
Console.WriteLine($"Current year from deprecated method: {deprecatedMethodResult}");

var newMethodResult = DateUtils.GetCurrentYearV2();
Console.WriteLine($"Current year from new method: {newMethodResult}");
