namespace IEnumeralbleVsICollectionVsIListVsList
{
    class Program
    {
        static void Main(string[] args)
        {
            var specialCharacter = new List<char>() {'#','@','$' };
            var numbers = new List<int>() { 1, 2, 3, 4 };
            var arrayOfSpecialCharacter = new char[] { '=', '!' };

            var enu = new ImplementationOfIEnumerable();
            Console.WriteLine($"IEnumerable:{enu.CountSpecialCharacters(specialCharacter)}\nIEnumerable With Yield:{ string.Join(",", enu.FilterNumbers(numbers))}");
                
            var icl = new ImplementationOfICollection();
            Console.WriteLine($"ICollection:{icl.CountSpecialCharacters(specialCharacter)}");

            //replacing CountSpecialCharactersArray with CountSpecialCharacters will end up in runtime exception
            var ils = new ImplementationOfIList();
            Console.WriteLine($"IList with List input:{ils.CountSpecialCharacters(specialCharacter)}\nIList with Array input:{ils.CountSpecialCharactersArray(arrayOfSpecialCharacter)}");

            var lst = new ImplementationOfList();
            Console.WriteLine($"List:{lst.CountSpecialCharacters(specialCharacter)}");

            Console.ReadLine();
        }       
    }    
}