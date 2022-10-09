using IndexOutOfRangeExceptionProject.Repository;
using System.Data;

namespace IndexOutOfRangeExceptionProject
{
    public class UtilityHelper
    {
        public int[] NumbersArray { get; set; }
        public Array CustomLowerBoundArray { get; set; }
        public List<int> MultiplesOfFive { get; set; }
        public int[] Array1 { get; set; }
        public int[] Array2 { get; set; }
        public int[] OddNumbersArray { get; set; }
        public DataTable Groceries { get; set; }

        public UtilityHelper()
        {
            NumbersArray = new int[] { 1, 2, 3, 4, 5 };
            CustomLowerBoundArray = Array.CreateInstance(typeof(int), new int[] { 5 }, new int[] { 1 });
            MultiplesOfFive = new List<int> { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            Array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            OddNumbersArray = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            Groceries = StaticDataRepository.GetGroceries();
        }

        public void UpperBoundMethod(bool forcefullyRaiseException)
        {
            if (forcefullyRaiseException)
            {
                for (var i = 0; i <= NumbersArray.Length; i++)
                {
                    Console.WriteLine(NumbersArray[i]);
                }
            }
            else
            {
                for (var i = 0; i < NumbersArray.Length; i++)
                {
                    Console.WriteLine(NumbersArray[i]);
                }
            }
        }

        public void CustomLowerBoundMethod(int input, bool forcefullyRaiseException)
        {
            if (forcefullyRaiseException)
            {
                for (var i = 0; i < CustomLowerBoundArray.Length; i++)
                {
                    CustomLowerBoundArray.SetValue(input, i);
                    input *= 5;
                }
            }
            else
            {
                for (var i = CustomLowerBoundArray.GetLowerBound(0); i <= CustomLowerBoundArray.GetUpperBound(0); i++)
                {
                    CustomLowerBoundArray.SetValue(input, i);
                    input *= 5;
                }
                for (var i = CustomLowerBoundArray.GetLowerBound(0); i <= CustomLowerBoundArray.GetUpperBound(0); i++)
                {
                    Console.WriteLine(CustomLowerBoundArray.GetValue(i));
                }
            }
        }

        public void ListIndexOfMethod(int searchArgument, bool forcefullyRaiseException)
        {
            var startIndex = MultiplesOfFive.IndexOf(searchArgument);

            if (forcefullyRaiseException)
            {
                Console.WriteLine($"Let's display the even numbers greater than {searchArgument}");
                for (var i = startIndex; i < MultiplesOfFive.Count; i++)
                {
                    Console.WriteLine(MultiplesOfFive[i]);
                }
            }
            else
            {
                if (startIndex < 0)
                {
                    Console.WriteLine($"The number {searchArgument} does not exist in the list.");
                }
                else
                {
                    Console.WriteLine($"Let's display the even numbers greater than {searchArgument}");
                    for (var i = startIndex; i < MultiplesOfFive.Count; i++)
                    {
                        Console.WriteLine(MultiplesOfFive[i]);
                    }
                }
            }
        }

        public void AssignFirstArrayElementToSecondArrayMethod(bool forcefullyRaiseException)
        {
            if (forcefullyRaiseException)
            {
                Array2 = new int[7];
                Array2[Array1.Length - 1] = Array1[Array1.Length - 1];
                Console.WriteLine($"The last element of array2 is: {Array2[Array2.Length - 1]}");
            }
            else
            {
                Array2 = new int[Array1.Length];
                Array2[Array1.Length - 1] = Array1[Array1.Length - 1];
                Console.WriteLine($"The last element of array2 is: {Array2[Array2.Length - 1]}");
            }
        }

        public void IndexAndValueMethod(bool forcefullyRaiseException)
        {
            if (forcefullyRaiseException)
            {
                foreach (var number in OddNumbersArray)
                {
                    Console.WriteLine($"The odd number is: {OddNumbersArray[number]}");
                }
            }
            else
            {
                foreach (var number in OddNumbersArray)
                {
                    Console.WriteLine($"The odd number is: {number}");
                }
            }
        }

        public void DataTableMethod(bool forcefullyRaiseException)
        {
            if (forcefullyRaiseException)
            {
                for (var i = 0; i < Groceries.Rows.Count; i++)
                {
                    var row = Groceries.Rows[i];
                    Console.WriteLine($"{row[0]}\t {row[1]}\t {row[2]}\t {row[3]}");
                }
            }
            else
            {
                foreach (DataRow grocery in Groceries.Rows)
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
}