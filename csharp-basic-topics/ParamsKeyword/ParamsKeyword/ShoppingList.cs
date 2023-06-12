using System;

namespace ParamsKeyword
{
    public class ShoppingList
    {
        public void Add(params string[] items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Added: {item}");
            }
        }
    }
}