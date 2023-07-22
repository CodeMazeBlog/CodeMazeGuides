namespace Action_Func
{
    public class FuncExample
    {
        public static Func<int, int, (int, int)> Calculate = (firstNum, secondNum) =>
        {
            int sum = firstNum + secondNum;
            int subtract = firstNum - secondNum;
            return (sum, subtract);
        };

        public static void LinqExamples()
        {
            //Selection using Func in LINQ
            var fruits = new List<string> { "Apple", "Banana", "Orange", "Mango", "Watermelon" };

            var fruitNameLengths = fruits.Select(fruit => fruit.Length);

            Console.WriteLine("Fruit length : ");
            foreach (var fruitLength in fruitNameLengths)
            {
                Console.WriteLine(fruitLength);
            }

            Console.WriteLine();

            //Filtering using Func in LINQ

            var numbers = new List<int> { 10, 25, 7, 30, 15, 8, 64 };
            var filteredNumbers = numbers.Where(number => number > 15);

            Console.WriteLine("Filtered numbers : ");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }

        //For testing 
        public static List<int> GetFruitNameLengths(List<string> fruitList)
        {
            return fruitList.Select(fruit => fruit.Length).ToList();
        }

        public static List<int> GetFilteredNumbers(List<int> numberList, int filterValue)
        {
            return numberList.Where(number => number > filterValue).ToList();
        }
    }
}
