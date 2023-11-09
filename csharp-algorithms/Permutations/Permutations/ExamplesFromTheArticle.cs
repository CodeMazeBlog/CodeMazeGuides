namespace ListAllThePermutationsOfStringInCSharp
{
    internal static class ExamplesFromTheArticle
    {
        private static int _recursiveCounter;
        public static void PrintAllPossiblePositions()
        {
            int counter = 1;

            for (int p0 = 0; p0 < 3; p0++)
                for (int p1 = 0; p1 < 3; p1++)
                    for (int p2 = 0; p2 < 3; p2++)
                        Console.WriteLine($"Position [{counter++,2}]: {p0}{p1}{p2}");
        }

        public static void PrintPermutations()
        {
            int counter = 1;

            for (int p0 = 0; p0 < 3; p0++)
                for (int p1 = 0; p1 < 3; p1++)
                    for (int p2 = 0; p2 < 3; p2++)
                    {
                        if ((p0 != p1) && (p0 != p2) && (p1 != p2))
                            Console.WriteLine($"Permutation [{counter++,2}]: {p0}{p1}{p2}");
                    }
        }

        public static void PrintPermutationsImproved()
        {
            int counter = 1;

            for (int p0 = 0; p0 < 3; p0++)
                for (int p1 = 0; p1 < 3; p1++)
                {
                    if (p1 == p0) continue; // Just skip the whole inner loop(!)
                    for (int p2 = 0; p2 < 3; p2++)
                    {
                        if ((p2 == p0) || (p2 == p1)) continue;
                        Console.WriteLine($"Permutation [{counter++,2}]: {p0}{p1}{p2}");
                    }
                }
        }

        public static void PrintPermutationsRecursively()
        {
            _recursiveCounter = 1;
            RecursiveAlgorithm("", new List<int> { 0, 1, 2, 3, 4 });
        }

        public static void RecursiveAlgorithm(string elementsOutOfTheBag, List<int> elementsInTheBag)
        {
            if (elementsInTheBag.Count == 0)
                Console.WriteLine($"Permutation #{_recursiveCounter++}: {elementsOutOfTheBag}");
            else
            {
                foreach (var element in elementsInTheBag)
                {
                    List<int> newBag = elementsInTheBag.Where(e => e != element).ToList();
                    RecursiveAlgorithm(elementsOutOfTheBag + element, newBag);
                }
            }
        }
    }
}
