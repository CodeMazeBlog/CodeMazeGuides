internal class Program : ActionFuncBase
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 10, 20, 30, 40, 50 };

        Action<List<int>> printListAction = PrintList;
        Console.WriteLine("Original List:");
        printListAction(numbers);

        Func<List<int>, List<int>> tripleListFunc = TripleList;
        List<int> tripledResult = tripleListFunc(numbers);
        Console.WriteLine("Tripled List:");
        foreach (int element in tripledResult)
        {
            Console.WriteLine(element);
        }
    }
}