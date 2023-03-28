var numbers = new List<int> { 0, 1, 2, 3, 4 };
numbers.ForEach(Console.WriteLine);

var sum = numbers.Where(number => number % 2 == 0).Sum();