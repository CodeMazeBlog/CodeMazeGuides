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

var numbers = new List<int> { 1, 2, 3 };
var numberList = string.Join(",", numbers);

var fruitsWithCharSeparator = string.Join(',', fruitList);

Console.WriteLine($"Fruits: {fruits}");

Console.WriteLine($"Filtered Fruit: {filterFruit}");

Console.WriteLine($"Trimmed Fruits: {trimmedFruits}");

Console.WriteLine($"Numbers: {numberList}");

Console.WriteLine($"Fruits With Char Separator: {fruitsWithCharSeparator}");
