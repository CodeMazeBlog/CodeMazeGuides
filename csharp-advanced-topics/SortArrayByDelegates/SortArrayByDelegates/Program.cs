using System;
using System.Collections.Generic;

namespace SortArrayByDelegates
{
    public class Program
    {

        static void Main(string[] args)
        {
            var entities = new List<Entity>();
            entities.Add(new Entity() { rowId = 3, value = "value 3" });
            entities.Add(new Entity() { rowId = 1, value = "value 1" });
            entities.Add(new Entity() { rowId = 2, value = "value 2" });
            var int_arr = new List<int> { 3, 1, 2 };
            var dataset1 = new DataSet<int>(int_arr);
            dataset1.Sort_Method = arr_sort;
            dataset1.Sort();
            var dataset2 = new DataSet<Entity>(entities);
            dataset2.Sort_Method = arr_sort;
            dataset2.Sort();
            Console.WriteLine("After Sort:");
            foreach (int i in int_arr)
                Console.Write(i + " ");
            Console.WriteLine();
            foreach (Entity i in entities)
                Console.Write(i.rowId + " ");
            Console.ReadLine();
        }

        public class DataSet<T>
        {
            public List<T> arr { get; set; }
            public DataSet(List<T> arr) { this.arr = arr; }
            public Action<List<T>> Sort_Method { get; set; }
            public void Sort()
            {
                if (Sort_Method != null)
                    Sort_Method(this.arr);
            }
        }
        public static void arr_sort(List<int> arr) { arr.Sort(); }
        public static void arr_sort(List<Entity> arr)
        {
            // insertion sort
            for (int j = 1; j < arr.Count; j++)
            {
                var key = arr[j];
                for (int i = j - 1; i >= 0; i--)
                {
                    if (arr[i].rowId > key.rowId)
                    {
                        var index = arr.IndexOf(key);
                        var temp = arr[index];
                        arr[index] = arr[i];
                        key = arr[i] = temp;
                    }
                }
            }
        }
        public class Entity
        {
            public int rowId { get; set; }
            public string value { get; set; }
        }
    }
}
