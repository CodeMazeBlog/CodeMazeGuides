namespace PrintOutArrayElements
{
    public class ElementPrinter
    {
        public void ForLoop(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($" ==> {array[i]}");
            }
        }

        public void ForeachLoop(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($" ==> {item}");
            }
        }

        public void AsSpan(int[] array)
        {
            var span = array.AsSpan();

            foreach (var item in span)
            {
                Console.Write($" ==> {item}");
            }
        }

        public void ToListForEach(int[] array)
        {   
            array.ToList().ForEach(element => Console.Write($" ==> {element}"));
        }

        public void StringJoin(int[] array)
        {
            Console.Write($" ==> { string.Join(" ==> ", array)}");
        }

        public void ArrayForEach(int[] array)
        {
            Action<int> print = (element) => Console.Write($" ==> {element}");

            Array.ForEach(array, print);
        }
    }
}
