class Program
{

    static int Square(int num)
    {
        return num * num;
    }
    Func<int, int> squareFunc = Square;

    static void ProcessList(List<int> numbers, Action<int> action)
    {
        foreach (var number in numbers)
        {
            action(number);
        }
    }
    private static void Main(string[] args)
    {
       
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            // Utilizing Action to print each number
            ProcessList(numbers, n => Console.WriteLine(n));
            // Utilizing Func to compute squares
            ProcessList(numbers, n => Console.WriteLine(Square(n)));
        
    }
}