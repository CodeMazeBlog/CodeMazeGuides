using CountEnumMembers;

var names = Enum.GetNames<Seasons>();
var values = Enum.GetValues<Seasons>();

Console.WriteLine("Names array: ");

foreach (var n in names)
{
    Console.WriteLine(n);
}

Console.WriteLine("");
Console.WriteLine("Values array");

foreach (var v in values)
{
    Console.WriteLine(v);
}

var getnames = Enum.GetNames<Seasons>().Length;
var getvalues = Enum.GetValues<Seasons>().Length;
var distinctValues = Enum.GetValues(typeof(Medals)).Cast<Medals>().Distinct().Count();

Console.WriteLine("");
Console.WriteLine("Total items by GetNames: " + getnames);
Console.WriteLine("Total items by GetValues: " + getvalues);
Console.WriteLine("Total number of distinct values: " + distinctValues);