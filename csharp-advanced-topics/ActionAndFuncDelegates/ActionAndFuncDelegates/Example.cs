namespace ActionAndFuncDelegates
{
    public class Example
    {
        public void ActionDemo()
        {
            List<string> items = new List<string>() { "Foo", "Bar", "Bob", "Alice" };

            Action<string> displayItem = delegate (string item) { Console.WriteLine(item); };

            items.ForEach(displayItem);
        }

        public void FuncDemo()
        {
            List<string> items = new List<string>() { "Foo", "Bar", "Bob", "Alice" };

            Func<string, string> convertItem = delegate (string item) { return item.ToLower(); };

            var result = items.Select(convertItem);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
