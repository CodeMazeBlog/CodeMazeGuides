namespace PermutationsOfAString
{
    internal static class InteractivePermutations
    {
        public static void Run()
        {
            Console.Write($"Enter a word you want to permutate: ");
            var word = Console.ReadLine();
            if (word is null)
                return;

            word = word.Trim();
            if (word.Length == 0)
                return;

            if (word.Length > 6)
            {
                Console.Write("That is a lot of elements. I will print this for a long time. Do you want to try that? (enter y/n) ");
                var answer1 = Console.ReadLine();
                if (answer1 != "y")
                    return;
            }

            IStringPermutation algorithm = new PanditasAlgorithm();

            var counter = 0;
            foreach (var item in algorithm.GetPermutations(word))
                Console.WriteLine($"{++counter,10}: {item}");
        }
    }
}
