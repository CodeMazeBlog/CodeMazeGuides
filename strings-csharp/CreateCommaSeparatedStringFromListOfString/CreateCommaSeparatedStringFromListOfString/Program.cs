// See https://aka.ms/new-console-template for more information

var fruitList = new List<string>
{
    "apple",
    "orange",
    "pineapple",
    "grape",
    "coconut"
};

var fruits = string.Join(",", fruitList);

var filterFruit = string.Join(",", fruitList.Where(fruit => fruit.Contains("apple")));

var trimmedFruits = string.Join(",", fruitList.ToArray(), 2, 3);

Console.WriteLine($"Fruits: {fruits}");

Console.WriteLine($"Filtered Fruit: {filterFruit}");

Console.WriteLine($"Trimmed Fruits: {trimmedFruits}");