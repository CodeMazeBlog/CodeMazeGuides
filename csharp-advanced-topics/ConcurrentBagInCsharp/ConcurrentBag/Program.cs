using ConcurrentBag;

Run();

void Run()
{
    var concurrentBagImplementation = new ConcurrentBagImplementation();
    var concurrentBag = concurrentBagImplementation.CreateConcurrentBag(new int[] { 23, 45 });
    Console.WriteLine($"IsEmpty: {concurrentBag.IsEmpty}");
    concurrentBag.TryPeek(out int result);
    Console.WriteLine($"TryPeek: {result}");
    Console.WriteLine($"Count after TryPeek: {concurrentBag.Count}");
    concurrentBag.TryTake(out result);
    Console.WriteLine($"Count after TryTake: {concurrentBag.Count}");
    concurrentBag.Clear();
    Console.WriteLine($"Count after Clear: {concurrentBag.Count}");
    Console.WriteLine($"IsEmpty: {concurrentBag.IsEmpty}");
    Console.WriteLine();
    Console.WriteLine($"Multithread scenario");

    var response = concurrentBagImplementation.MultiThread_Implementation(new List<int> { 10,20,200,40 }, new List<int> { 30,1,50,100 });
    Console.WriteLine($"Task 1 {response.Item1}");
    Console.WriteLine($"Task 2 {response.Item2}");
    Console.WriteLine($"left Over {response.Item3}");
}
