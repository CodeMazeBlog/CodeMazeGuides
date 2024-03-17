namespace ActionAndFuncDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility utility = new Utility();

            string name = utility.GetByCondition(Get);

            string anotherName = utility.GetByCondition(x => x.FirstOrDefault(n => n == "Janelle"));

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
            string request = "Jason";

            string name = "Not Found";

            foreach (var item in items)
            {
                if (item.Equals(request))
                    return name = item;
            }
            return name;
        }
    }
}
