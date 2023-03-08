// See https://aka.ms/new-console-template for more information
namespace ActionAndFuncDelegatesInCsharp
{
    public class Program
    {
        public delegate int Find(int[] list, int input);
       
        public static void Main(string[] args)
        {           
            //Find the only one index or throw exception using delegate keyword
            Find findOnlyOne = Finder.FindOnlyOne;
            int[] listInput1 = { 5, 4, 10, 8, 9, 6 };
            int index1 = findOnlyOne.Invoke(listInput1, 8);
            
            Console.WriteLine(index1);
          
            //Find the only one index or throw exception using Func<I1,I2,...,O>
            Func<int[], int, int> findOnlyOne2 = Finder.FindOnlyOne;
            int[] listInput2 = { 9, 6, 7, 9, 11, 10, 8 };
            try
            {
                int index2 = findOnlyOne2.Invoke(listInput2, 8);
                
                Console.WriteLine(index2);
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured!");
            }

            // Find Zero or One index using anonymous delegate definition
            Func<int[], int, int> findMaximumOne = delegate (int[] list, int input)
            {
                int index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == input)
                    {
                        if (index != -1)
                            throw new Exception();
                        index = i;
                    }
                }

                return index;
            };

            int[] listInput3 = { 7, 9, 1, 6 };
            try
            {
                int index3 = findMaximumOne.Invoke(listInput3, 8);
                
                Console.WriteLine(index3);
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured!");
            }

            // Find last index using lambda
            Func<int[], int, int> findLastIndex = (list, input) =>
            {
                int index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == input)
                    {
                        index = i;
                    }
                }
            
                return index;
            };

            int[] listInput4 = { 1, 7, 9, 1, 6 };
            int index4 = findLastIndex.Invoke(listInput4, 1);
            
            Console.WriteLine(index4);

            //Form greeting using Action definition
            Action<string, string> greeting = new GreetingManager(new ConsoleWriter()).FormalGreeting;
            
            greeting.Invoke("John", "Smith");
        }       
    }
}
