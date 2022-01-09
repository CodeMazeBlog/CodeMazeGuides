namespace ActionFunc
{
    internal class Shape
    {
        internal void Print(int Times)
        {
            for (int i = 0; i < Times; i++)
            {
                Console.WriteLine(this.ToString());
            }
        }

        internal int Compute(int FirstValue, int SecondValue)
        {
            return FirstValue * SecondValue;
        }
    }
}
