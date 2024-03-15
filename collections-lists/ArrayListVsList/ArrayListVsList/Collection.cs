using System.Collections;

namespace ArrayListVsList
{
    public class Collection
    {
        public ArrayList ArrayList { get; set; } = new();
        public List<int> List { get; set; } = new();
        public int Sum { get; set; }

        public void ArrayListExample()
        {
            Sum = 0;

            ArrayList.Add(1);
            ArrayList.Add(2);
            ArrayList.Add("3");

            Sum = GetSum(ArrayList);

            Console.WriteLine($"Sum is {Sum}");
        }

        public int GetSum(ArrayList arrayList)
        {
            Sum = 0;

            foreach (var item in ArrayList)
            {
                Sum += Convert.ToInt32(item);
            }

            return Sum;
        }

        public void ListExample()
        {
            Sum = 0;

            List.Add(1);
            List.Add(2);
            List.Add(3);
            //list.Add("4"); // Gives compile error

            foreach (var item in List)
            {
                Sum += item;
            }

            Console.WriteLine($"Sum is {Sum}");
        }
    }
}
