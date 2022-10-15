namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public static void EqualityOperator()
        {
            int value = 0;
            if (value == 1) Console.WriteLine("Hello World");

            Complex complexOne = new();
            Console.WriteLine(complexOne.GetId);

            Complex complexTwo = new();
            Console.WriteLine(complexTwo.GetId);

            if (complexOne == complexTwo)
            {
                Console.WriteLine("Equal");
            }
        }
    }
}
