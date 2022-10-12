namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public class Complex
        {
            private static int _id;

            Random random = new Random();

            public Complex() => _id = random.Next(200);

            public static bool operator ==(Complex c1, Complex c2) => _id % 2 == 0;

            public static bool operator !=(Complex c1, Complex c2) => _id % 2 == 1;

            public int getId => _id;
        }
    }
}
