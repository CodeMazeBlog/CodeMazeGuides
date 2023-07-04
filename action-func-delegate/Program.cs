namespace DelegateDemo
{
    internal class Program
    {
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            Del del = PrintMessage;

            del("Hello world!");

            Action<string> action = PrintMessage;

            action("Hello world!");

            string hi = "Hello world!";

            Action lambda = () => { Console.WriteLine("Inside the lambda"); Console.WriteLine(hi); };

            lambda();

            Action changes = () => { hi = "Gotcha!"; };

            changes();
            Console.WriteLine(hi);

            var list = new List<int> { 5, 50, 3 };

            Console.WriteLine("Select odd elements from the list");
            SelectFromList(list, x => x % 2 == 1);

            Console.WriteLine("Select elements bigger than 10 from the list");
            SelectFromList(list, x => x > 10);

            Console.ReadKey();
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void SelectFromList(List<int> list, Func<int, bool> condition)
        {
            var selectedItems = list.Where(condition);

            foreach (var item in selectedItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}