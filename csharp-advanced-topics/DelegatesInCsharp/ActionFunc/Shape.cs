namespace ActionFunc
{
    public class Shape
    {
        public void Print(int Times)
        {
            for (int i = 0; i < Times; i++)
            {
                Console.WriteLine(this.ToString());
            }
        }

        public int Compute(int FirstValue, int SecondValue)
        {
            return FirstValue * SecondValue;
        }
    }
}
