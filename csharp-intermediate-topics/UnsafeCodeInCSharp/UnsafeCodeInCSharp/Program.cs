namespace UnsafeCodeInCSharp
{
    public class Program
    {
        public static unsafe void Main(string[] args)
        {
            unsafe
            {
                int a = 100;
                int* ptr = &a;

                Console.WriteLine("The value of variable: {0}", a);
                Console.WriteLine("The value of variable using pointer: {0}", ptr->ToString());
                Console.WriteLine("The address of variable : {0}", (int)ptr);
            }

            int num = 10;
            int* arg = &num;

            Console.WriteLine("GetTriple Input: {0}", num);

            GetTriple(arg);

            Console.WriteLine("GetTriple Output: {0}", num);

            string text = "Happy";

            fixed (char* ptr = text)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    Console.WriteLine("text[{0}] : {1}", i, *(ptr + i));
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