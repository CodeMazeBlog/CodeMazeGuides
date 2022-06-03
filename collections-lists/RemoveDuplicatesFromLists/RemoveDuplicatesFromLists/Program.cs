using RemoveDuplicatesFromLists;

RemoveDuplicatesHelper<int> helper = new RemoveDuplicatesHelper<int>();
helper.ListWithDuplicates.Add(1);
helper.ListWithDuplicates.Add(2);
helper.ListWithDuplicates.Add(3);
helper.ListWithDuplicates.Add(4);
helper.ListWithDuplicates.Add(5);
helper.ListWithDuplicates.Add(1);
helper.ListWithDuplicates.Add(2);
helper.ListWithDuplicates.Add(3);
helper.ListWithDuplicates.Add(4);

Console.WriteLine("------Initial list------");
Console.WriteLine("Output = {0}", string.Join(",", helper.ListWithDuplicates));


Console.WriteLine("\n------Using distinct------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingDistinct()));

Console.WriteLine("\n------Using dictionary------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingDictionary()));


Console.WriteLine("\n------Using recursion------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingRecursion()));

Console.WriteLine("\n------Using empty list------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingEmptyList()));

Console.WriteLine("\n------Manually------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingIterations()));

Console.WriteLine("\n------Using group by------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingGroupBy()));

Console.WriteLine("\n------Using hashSet------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingHashSet()));

Console.WriteLine("\n------Using union------");
Console.WriteLine("Output = {0}", string.Join(",", helper.UsingUnion()));

Console.WriteLine("\n------Using sorting------");
Console.WriteLine("Output = {0}", string.Join(",", helper.Sorting()));
