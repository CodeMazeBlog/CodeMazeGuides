using IndexOutOfRangeExceptionProject.Repository;
using System.Data;

namespace IndexOutOfRangeExceptionProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //1 -> Array - Upper Bound - should be less that the array length
            var numbersArray = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.WriteLine(numbersArray[i]);
            }

            //2 -> Array with custom lower bound
            var customLowerBoundArray = Array.CreateInstance(typeof(int), new int[] { 5 }, new int[] { 1 });
            var value = 2;
            for (int i = customLowerBoundArray.GetLowerBound(0); i <= customLowerBoundArray.GetUpperBound(0); i++)
            {
                customLowerBoundArray.SetValue(value, i);
                value *= 5;
            }

            for (int i = customLowerBoundArray.GetLowerBound(0); i <= customLowerBoundArray.GetUpperBound(0); i++)
            {
                Console.WriteLine(customLowerBoundArray.GetValue(i));
            }

            //3 -> Incorrect Arguments
            Console.WriteLine("Please enter a search argument!!!");
            var searchArg = Convert.ToInt32(Console.ReadLine());

            var multiplesOfFive = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            var startIndex = multiplesOfFive.IndexOf(searchArg);
            if (startIndex < 0)
            {
                Console.WriteLine($"The number {searchArg} does not exist in the list.");
            }
            else
            {
                Console.WriteLine($"Let's display the even numbers greater than {searchArg}");
                for (int i = startIndex; i < multiplesOfFive.Count; i++)
                {
                    Console.WriteLine(multiplesOfFive[i]);
                }
            }

            //4 -> 2 arrays with different dimensions
            var array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var array2 = new int[array1.Length];

            array2[array1.Length - 1] = array1[array1.Length - 1];
            Console.WriteLine($"The last element of array2 is:  {array2[array2.Length - 1]}");

            //5 -> Getting confused between the index and value at that index
            var oddNumbersArray = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            foreach (var number in oddNumbersArray)
            {
                Console.WriteLine($"The odd number is: {number}");
            }

            //6 -> DataTable example
            var groceries = StaticDataRepository.GetGroceries();
            foreach (DataRow grocery in groceries.Rows)
            {
                foreach (var item in grocery.ItemArray)
                {
                    Console.WriteLine($"{item}");
                }
                Console.WriteLine("********************");
            }
        }
    }
}