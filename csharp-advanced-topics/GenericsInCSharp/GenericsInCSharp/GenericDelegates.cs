namespace GenericsInCSharp
{
    public class GenericDelegates
    {
        public int AdditionFunc(int num1, int num2)
        {
            return num1 + num2;
        }

        public int MultiplicationFunc(int num1, int num2 )
        {
            return num2 * num1;
        }

        public void PrintString(string stringVal) 
        {
            Console.WriteLine(stringVal);
        }
    }
}
