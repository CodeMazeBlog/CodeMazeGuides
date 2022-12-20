using BoxingAndUnboxingInCSharp;

namespace BoxingAndUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int valueType = 25;
                object objectType = valueType; //boxing
                int unboxedValue = (int)objectType; //unboxing

                Console.WriteLine("Boxing and Unboxing were executed successfully.");

            }
            catch(Exception) 
            {
                throw;
            }


            Console.ReadKey();
        }
    }
}