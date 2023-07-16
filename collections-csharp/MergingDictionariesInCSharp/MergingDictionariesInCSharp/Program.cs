using static MergingDictionariesInCSharp.Methods;

var dictionaryA = new Dictionary<int, string>()
{
    { 1, "Monday" },
    { 2, "Tuesday" },
    { 3, "Wednesday" }
};

var dictionaryB = new Dictionary<int, string>()
{
    { 4, "Thursday" },
    { 5, "Friday" },
    { 6, "Saturday" },
    { 7, "Sunday" }
};

Console.WriteLine("Merge dictionaries");
Console.WriteLine("Using Concat: ");
PrintDictionary(ConcatMethod(dictionaryA, dictionaryB));
Console.WriteLine("Using ForEach: ");
PrintDictionary(ForEachMethod(dictionaryA, dictionaryB));
Console.WriteLine("Using GroupBy: ");
PrintDictionary(GroupByMethod(dictionaryA, dictionaryB));
Console.WriteLine("Using Lookup: ");
PrintDictionary(LookupMethod(dictionaryA, dictionaryB));
Console.WriteLine("Using Union: ");
PrintDictionary(UnionMethod(dictionaryA, dictionaryB));
Console.WriteLine("Using Lists: ");
PrintDictionary(UsingListsMethod(dictionaryA, dictionaryB));