using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class Bubble
    {
        public int[] SortArray(int[] array) 
        {
            var n = array.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        var tempVar = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempVar;
                    }
            return array;
        }

        public void DisplaySortTime(int[] array)
        {
            Console.WriteLine("{0} array elements:", array.Length);
            var sortDuration = GetSortingTime(array);
            Console.WriteLine("\tIt takes {0} seconds to sort the unsorted array", sortDuration);
            sortDuration = GetSortingTime(array);
            Console.WriteLine("\tIt takes {0} seconds to sort the sorted array\n", sortDuration);
        }

        public double GetSortingTime(int[] array)
        {
            var start = Environment.TickCount;
            SortArray(array);
            var stop = Environment.TickCount;
            return (stop - start) / 1000.0;
        }

        public void GenerateRandomNumber(int[] array, int maxNum)
        {
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(maxNum + 1);
        }
    }
}
