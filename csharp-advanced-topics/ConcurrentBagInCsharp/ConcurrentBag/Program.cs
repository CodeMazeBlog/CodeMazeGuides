using ConcurrentBag;

Run();

void Run()
{
    var _ConcurrentBagImplementation = new ConcurrentBagImplementation();
    var result = _ConcurrentBagImplementation.UpdateConcurrentBag();
    foreach(var item in result){
        Console.WriteLine(item);
    }
}
