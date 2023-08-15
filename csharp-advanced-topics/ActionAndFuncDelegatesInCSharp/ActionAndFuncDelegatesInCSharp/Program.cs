namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {
        public delegate void DelegateWithNoReturn(int number);
        public delegate string DelegateWithReturn(string name);

        public void Example()
        {
            DelegateWithNoReturn myDelegate1 = x => x += x;

            Action<int> myAction = x => x += x;


            DelegateWithReturn myDelegate2 = name => $"Hello {name}";

            Func<string, string> myFunc = name => $"Hello {name}";
        }

        public void LinqExample()
        {
            var exampleList = new List<string>
            {
                "banana",
                "pineapple",
                "orange",
                "apple"
            };

            exampleList.FirstOrDefault(fruit => fruit == "orange"); // Func<string, bool>
            exampleList.ForEach(fruit => fruit.ToUpper()); // Action<string>
        }

        public static string? FirstOrDefault(List<string> myList, Func<string, bool> filter)
        {
            foreach (var item in myList)
            {
                if(filter(item))
                {
                    return item;
                }
            }
            return null;
        }
    }
}