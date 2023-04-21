using System.Collections;

namespace ArrayListVsList
{
    public class Demo
    {
        public ArrayList ArrayList = new ArrayList();
        public List<int> List = new List<int>();

        public int Sum;

        public void ArrayListDemo()
        {
            Sum = 0;
            ArrayList.Add(1);
            ArrayList.Add(2);
            ArrayList.Add("3");

            Sum = ArrayListSum(ArrayList);
           
            Console.WriteLine($"Sum is {Sum}");
        }

        public int ArrayListSum(ArrayList arrayList)
        {
            Sum = 0;
            foreach (var item in ArrayList)
            {
                Sum += Convert.ToInt32(item);
            }
            return Sum;
        }

        public void ListDemo()
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
