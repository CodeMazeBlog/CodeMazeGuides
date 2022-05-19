namespace PopulateArrayWithTheSameValue
{
    public class Program
    {
        private static readonly ArrayPopulator _arrayPopulator = new();
        public static int OutputResult = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("-----  How to Populate or Instantiate Array with a Same Value");
            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine();

            Console.WriteLine("----- Input data manually");
            var simpleArray = _arrayPopulator.InstantiateArrayManually();
            PrintArrayValues(simpleArray);

            Console.WriteLine();

            Console.WriteLine("----- Populate Array With Array.Fill");
            var arrayFill = _arrayPopulator.FillArray(InstantiateInitialArray(), InstantiateNewArticle());
            PrintArrayValues(arrayFill);

            Console.WriteLine();

            Console.WriteLine("----- Populate Array With Enumerable.Repeat");
            var enumerableRepeat = _arrayPopulator.EnumerableRepeat(InstantiateNewArticle(), 10);
            PrintArrayValues(enumerableRepeat);

            Console.WriteLine();

            Console.WriteLine("----- Populate Array With For Statement");
            var forStatement = _arrayPopulator.ForStatement(InstantiateInitialArray(), InstantiateNewArticle());
            PrintArrayValues(forStatement);

            Console.WriteLine();

            Console.WriteLine("----- Populate Array With For Statement Shallow Copy");
            var forStatementShallowCopy = _arrayPopulator.ForStatementShallowCopy(InstantiateInitialArray(), InstantiateNewArticle());
            PrintArrayValues(forStatementShallowCopy);

            OutputResult = 1;
        }

        private static void PrintArrayValues(Article[] array)
        {
            if (array is null)
                return;

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static Article[] InstantiateInitialArray()
        {
            return new Article[10];
        }

        public static Article InstantiateNewArticle()
        {
            return new Article 
            { 
                Title = "How to Copy Array Elements to New Array in C#", 
                LastUpdate = new DateTime(2022, 01, 31) 
            };
        }
    }
}
