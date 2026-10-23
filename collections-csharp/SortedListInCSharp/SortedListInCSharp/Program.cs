using SortedListInCSharp;

var keys = Enumerable.Range(0, 100_000).ToArray();

var sortedList = MemoryComparison.RetainedBytes(
    () => MemoryComparison.Fill(new SortedList<int, int>(), keys));
var sortedDictionary = MemoryComparison.RetainedBytes(
    () => MemoryComparison.Fill(new SortedDictionary<int, int>(), keys));
var dictionary = MemoryComparison.RetainedBytes(
    () => MemoryComparison.Fill(new Dictionary<int, int>(), keys));
var trimmedSortedList = MemoryComparison.RetainedBytes(() =>
{
    var list = new SortedList<int, int>();
    MemoryComparison.Fill(list, keys);
    list.TrimExcess();

    return list;
});

Console.WriteLine($"SortedList:       {sortedList:N0} bytes");
Console.WriteLine($"SortedDictionary: {sortedDictionary:N0} bytes");
Console.WriteLine($"Dictionary:       {dictionary:N0} bytes");
Console.WriteLine($"SortedList after TrimExcess(): {trimmedSortedList:N0} bytes");
