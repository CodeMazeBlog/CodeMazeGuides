using RemoveDuplicatesFromLists;

var helper = new RemoveDuplicatesHelper<int>();
helper.ListWithDuplicates = new List<int>() { 1, 2, 3, 4, 5, 1, 2, 3, 4 };

Console.WriteLine("------Initial list------");
Console.WriteLine("Output = {0}", string.Join(",", helper.ListWithDuplicates));

Console.WriteLine("\n------Using distinct------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingDistinct()));

Console.WriteLine("\n------Using dictionary------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingDictionary()));

Console.WriteLine("\n------Using recursion------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingRecursion()));

Console.WriteLine("\n------Using empty list with Contains------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingEmptyListWithContains()));

Console.WriteLine("\n------Using empty list with Any------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingEmptyListWithAny()));

Console.WriteLine("\n------Shifting------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingIterationsAndShifting()));

Console.WriteLine("\n------Swapping------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingIterationsAndSwapping()));

Console.WriteLine("\n------Using group by------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingGroupBy()));

Console.WriteLine("\n------Using hashSet------");
Console.WriteLine("Output = {0}", string.Join(",", helper.ConvertingToHashSet()));

Console.WriteLine("\n------Using union------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingUnion()));

Console.WriteLine("\n------Using sorting------");
Console.WriteLine("Output = {0}", string.Join(",", helper.Sorting()));