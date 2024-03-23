namespace ActionAndFuncDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var utility = new Utility();

            var name = utility.GetByCondition(Get);

            var anotherName = utility.GetByCondition(x => x.FirstOrDefault(n => n == "Janelle"));

            utility.DisplayAll(PrintAll);

            utility.DisplayAll(x => x.ForEach(a => Console.WriteLine(a)));
        }


        public static void PrintAll(List<string> items) 
        { 
            items.ForEach(x => Console.WriteLine(x)); 
        }

        public static string Find(string name)
        {
            return name;
        }

        public static void Display(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        public static string Get(List<string> items)
        {
            var request = "Jason";

            var name = "Not Found";

            foreach (var item in items)
            {
                if (item.Equals(request))
                    return name = item;
            }

            return name;
        }
    }
}
