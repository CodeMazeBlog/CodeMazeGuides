namespace ListAllThePermutationsOfStringInCSharp
{
    internal static class InteractivePermutations
    {
        public static void Run()
        {
            byte? numberOfElements = null;

            do
            {
                Console.Write("How many elements do you want (enter 0 to exit)? ");
                var answer = Console.ReadLine();
                if (byte.TryParse(answer, out byte number))
                {
                    if (number <= 0)
                        return;

                    if (number > 6)
                    {
                        Console.Write("That is a lot of elements. I will print this for a long time. Do you want to try that? (enter y/n) ");
                        var answer1 = Console.ReadLine();
                        if (answer1 != "y") continue;
                    }

                    numberOfElements = number;
                }
            } while (numberOfElements is null);

            var elements = new HashSet<string>();
            do
            {
                Console.Write($"Write down element #{elements.Count + 1}: ");
                var element = Console.ReadLine();
                if (element is not null)
                    elements.Add(element);
            } while (elements.Count < numberOfElements);

            var listOfElements = elements.ToList();
            IPermutation algorithm = new RecursiveAlgorithm();

            var counter = 0;
            foreach (var item in algorithm.GetPermutations(numberOfElements.Value))
            {
                var resultLine = string.Join(", ", item.Select(n => listOfElements[n]));
                Console.WriteLine($"{++counter,10}: {resultLine}");
            }
        }
    }
}
