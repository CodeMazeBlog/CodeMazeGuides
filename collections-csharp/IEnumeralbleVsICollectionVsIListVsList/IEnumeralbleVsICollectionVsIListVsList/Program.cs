using System;

namespace IEnumeralbleVsICollectionVsIListVsList
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialCharacter = new List<char>() {'#','@','$' };
            var numbers = new List<int>() { 1, 2, 3, 4 };
            var arrayOfSpecialCharacter = new char[] { '=', '!' };

            //IEnumerable<T>
            var enu = new ImplementationOfIEnumerable();
            Console.WriteLine($"IEnumerable:{enu.CountSpecialCharacters(specialCharacter)}");            
            Console.WriteLine($"IEnumerable With Yield:");
            foreach (var num in enu.GetEvenNumberUpToTen())
            {
                Console.WriteLine(num);
            }
                  
            //ICollection<T>
            var icl = new ImplementationOfICollection();
            Console.WriteLine($"ICollection:{icl.CountSpecialCharacters(specialCharacter)}");

            //IList
            var ils = new ImplementationOfIList();
            Console.WriteLine($"IList with List input:{ils.CountSpecialCharacters(specialCharacter)}");
            Console.WriteLine($"IList with Array input:{ils.CountSpecialCharactersArray(arrayOfSpecialCharacter)}");

            //List
            var lst = new ImplementationOfList();
            Console.WriteLine($"List:{lst.CountSpecialCharacters(specialCharacter)}");

            Console.ReadLine();
        }       
    }    
}