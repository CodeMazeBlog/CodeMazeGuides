namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public static void EqualityOperator()
        {
            int value = 0;
            if (value == 1) Console.WriteLine("Hello World");

            Complex complexOne = new();
            Console.WriteLine(complexOne.getId);

            Complex complexTwo = new();
            Console.WriteLine(complexTwo.getId);

            if (complexOne == complexTwo)
            {
                Console.WriteLine("Equal");
            }
        }
    }
}
