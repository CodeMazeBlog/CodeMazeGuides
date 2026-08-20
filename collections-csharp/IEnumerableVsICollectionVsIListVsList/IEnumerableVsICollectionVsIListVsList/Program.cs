using System;

namespace IEnumerableVsICollectionVsIListVsList
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialCharacter = new List<char>() {'#','@','$' };
            var arrayOfSpecialCharacter = new char[] { '=', '!' };

            //IEnumerable<T>
            var enu = new ImplementationOfIEnumerable();
            var output = enu.CountSpecialCharacters(specialCharacter);
            Console.WriteLine($"IEnumerable:{output}");            
            Console.WriteLine($"IEnumerable With Yield:");
            foreach (var num in enu.GetEvenNumberUpToTen())
            {
                Console.WriteLine(num);
            }
                  
            //ICollection<T>
            var icl = new ImplementationOfICollection();
            output = icl.CountSpecialCharacters(specialCharacter);
            Console.WriteLine($"ICollection:{output}");

            //IList
            var ils = new ImplementationOfIList();
            output = ils.CountSpecialCharacters(specialCharacter);
            Console.WriteLine($"IList with List input:{output}");
            output = ils.CountSpecialCharactersArray(arrayOfSpecialCharacter);
            Console.WriteLine($"IList with Array input:{output}");

            //List
            var lst = new ImplementationOfList();
            output = lst.CountSpecialCharacters(specialCharacter);
            Console.WriteLine($"List:{output}");

            //Deferred execution vs a materialised collection
            var deferred = new DeferredExecutionDemo();
            Console.WriteLine($"Deferred vs materialised:");
            deferred.ShowDeferredVsMaterialised(new List<int> { 5, 11, 12, 42 });

            Console.ReadLine();
        }       
    }    
}