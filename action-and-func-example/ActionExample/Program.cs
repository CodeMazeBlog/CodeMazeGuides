class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 }; // Using Action delegate to print each number in the list
        Action<int> printNumber = (num) => Console.WriteLine(num);
        numbers.ForEach(printNumber);
    }
}

