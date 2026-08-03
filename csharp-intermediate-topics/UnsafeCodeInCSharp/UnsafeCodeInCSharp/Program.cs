namespace UnsafeCodeInCSharp
{
    public class Program
    {
        public static unsafe void Main(string[] args)
        {
            unsafe
            {
                var number = 100;
                int* numberPtr = &number;

                Console.WriteLine("The value of variable: {0}", number);
                Console.WriteLine("The value of variable using pointer: {0}", numberPtr->ToString());
                Console.WriteLine("The address of variable : {0}", (int)numberPtr);
            }

            var num = 10;
            int* numPtr = &num;

            Console.WriteLine("GetTriple Input: {0}", num);

            GetTriple(numPtr);

            Console.WriteLine("GetTriple Output: {0}", num);

            var text = "Happy";

            fixed (char* textPtr = text)
            {
                for (var i = 0; i < text.Length; i++)
                {
                    Console.WriteLine("text[{0}] : {1}", i, *(textPtr + i));
                }
            }

            Console.ReadLine();
        }

        public static unsafe void GetTriple(int* num)
        {
            *num = *num * 3;
        }
    }
}