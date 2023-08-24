namespace PermutationsOfAString
{
    internal static class DisplayNextPermutation
    {
        public static void Run()
        {
            Console.Write($"Enter a string: ");
            var word = Console.ReadLine();
            if (word is null)
                return;

            word = word.Trim();
            if (word.Length == 0)
                return;

            IStringPermutation algorithm = new PanditasAlgorithm();
            for (; ; )
            {
                word = algorithm.GetNextPermutation(word);
                Console.WriteLine($"Next permutation: {word}");

                Console.Write("Next? (enter y/n) ");
                var answer1 = Console.ReadLine();
                if (answer1 != "y")
                    return;
            };
        }
    }
}
