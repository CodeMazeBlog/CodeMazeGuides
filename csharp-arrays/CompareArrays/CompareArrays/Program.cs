namespace CompareArrays
{
    public class Program
    {
        private static readonly ArrayComparer _arrayComparer = new();
        private static readonly int[] _firstArray = new int[] { 10, 9, 3, 8, 7 };
        private static readonly int[] _secondArray = new int[] { 10, 9, 3, 8, 7 };
        public static int OutPutResult = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("---------- Compare Arrays in C#");
            Console.WriteLine("-------------------------------");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using Equality operator Operator (==)");
            Console.WriteLine($"Are equal: {_arrayComparer.EqualityOperator(_firstArray, _secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using For Loop");
            Console.WriteLine($"Are equal: {_arrayComparer.ForLoop(_firstArray, _secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using Enumerable.SequenceEqual");
            Console.WriteLine($"Are equal: {_arrayComparer.EnumerableSequenceEqual(_firstArray, _secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using Enumerable.SequenceEqual Array of Articles");

            var firstArticle = new Article() { Title = "How to Deserialize a Complex JSON Object in C# .NET", LastUpdate = new DateTime(2022, 03, 18) };
            var similarFirstArticle = new Article() { Title = "How to Deserialize a Complex JSON Object in C# .NET", LastUpdate = new DateTime(2022, 03, 18) };
            var secondArticle = new Article() { Title = "How to Populate an Array With the Same Value in C#", LastUpdate = new DateTime(2022, 02, 19) };
            var similarSecondArticle = new Article() { Title = "How to Populate an Array With the Same Value in C#", LastUpdate = new DateTime(2022, 02, 19) };

            var firstArray = new Article[] { firstArticle, secondArticle };
            var secondArray = new Article[] { similarFirstArticle, similarSecondArticle };
            
            Console.WriteLine($"Are equal: {_arrayComparer.EnumerableSequenceEqual(firstArray, secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using Enumerable.Equals");
            Console.WriteLine($"Are equal: {_arrayComparer.EnumerableEquals(_firstArray, _secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using Enumerable.ReferenceEquals");
            Console.WriteLine($"Are equal: {_arrayComparer.EnumerableReferenceEquals(_firstArray, _secondArray)}");

            Console.WriteLine();

            Console.WriteLine("---------- Compare using StructuralEquatable");
            Console.WriteLine($"Are equal: {_arrayComparer.StructuralEquatable(_firstArray, _secondArray)}");

            Console.WriteLine();
            
            OutPutResult = 1;
        }
    }
}