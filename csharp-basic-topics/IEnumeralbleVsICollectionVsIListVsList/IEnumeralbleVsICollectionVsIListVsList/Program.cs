namespace IEnumeralbleVsICollectionVsIListVsList
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new ImplementationOfList();
            var specialCharacter = lst.ListOfSpecialCharacters();

            var enu = new ImplementationOfIEnumerable();
            Console.WriteLine(enu.CountSpecialCharacters(specialCharacter));

            var icl = new ImplementationOfICollection();
            Console.WriteLine(icl.CountSpecialCharacters(specialCharacter));

            var ils = new ImplementationOfIList();
            Console.WriteLine(ils.CountSpecialCharacters(specialCharacter));

            Console.ReadLine();
        }
    }    
}