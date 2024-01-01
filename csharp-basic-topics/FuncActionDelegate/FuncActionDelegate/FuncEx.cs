namespace FuncActionDelegate;

public class FuncEx
{
    public void FuncExample()
    {
        Func<int, int, int> AddNumbers = (x, y) => x + y;
        int additionResult = Calculate(5, 3, AddNumbers); // Invokes AddNumbers method indirectly
        Console.WriteLine(additionResult); // Output: 8

        int Calculate(int x, int y, Func<int, int, int> operation)
        {
            return operation(x, y);
        }

        Func<int, int, int> subtractNumbers = (x, y) => x - y;
        int subtractionResult = Calculate(5, 3, subtractNumbers); // Invokes subtract method indirectly
        Console.WriteLine(subtractionResult); // Output: 2
    }
    public void FuncRealExample()
    {
        List<string> data = new() { "Test1", "Test2", "Test3" }; 
        
        var filteredData = data.Where(c => c.EndsWith("1")); 
        
        foreach (var item in filteredData)
        {
            Console.WriteLine(item); //Test1 
        }
    }
}


