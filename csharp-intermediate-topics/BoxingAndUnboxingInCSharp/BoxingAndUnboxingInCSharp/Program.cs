using System.Collections;

namespace BoxingAndUnboxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                 * Boxing and Unboxing simple example
                 */
                int valueType = 25;
                object objectType = valueType;      //boxing
                int unboxedValue = (int)objectType; //unboxing

                Console.WriteLine("Boxing and Unboxing were executed successfully.\n");

                /*
                 * Unboxing example using String.Concat method 
                 */
                string name = "Joe Doe"; 
                Console.WriteLine(string.Concat(name, "'s age: ", 31)); /* Output: Joe Doe's age: 33 */

                /*
                 * Unboxing example using ArrayList
                 */
                var myArrayList = new ArrayList(); 
                myArrayList.Add(1);         // int value
                myArrayList.Add("Joe Doe"); // string value
                myArrayList.Add(1.23);      // double value
                
                foreach (var item in myArrayList) 
                    Console.WriteLine(item);
            }
            catch(Exception) 
            {
                throw;
            }

            Console.ReadKey();
        }
    }
}