using ConcurrentBagInCSharp;

var myConcurrentBag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();

Console.WriteLine($"Count: {myConcurrentBag.Count}");
Console.WriteLine($"IsEmpty: {myConcurrentBag.IsEmpty}");
