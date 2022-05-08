// See https://aka.ms/new-console-template for more information

List<string> fruitList = new List<string>
{
    "apple",
    "orange",
    "pineapple",
    "grape",
    "coconut"
};

string fruits = string.Join(",", fruitList);

string filterFruit = string.Join(",", fruitList.Where(fruit => fruit.Contains("apple")));

string trimedFruits = string.Join(",", fruitList.ToArray(), 2, 3);

Console.WriteLine($"Fruits: {fruits}");

Console.WriteLine($"Filtered Fruit: {filterFruit}");

Console.WriteLine($"Trimmed Fruits: {trimedFruits}");