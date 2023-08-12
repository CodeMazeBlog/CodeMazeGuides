using DeprecationInCsharp;

Console.WriteLine($"Current year from deprecated method: {DateUtils.GetCurrentYearV1()}");
Console.WriteLine($"Current year from new method: {DateUtils.GetCurrentYearV2()}");
