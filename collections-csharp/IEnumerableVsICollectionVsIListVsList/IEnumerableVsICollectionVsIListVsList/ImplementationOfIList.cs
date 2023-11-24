using System.Collections;

namespace IEnumerableVsICollectionVsIListVsList
{
    public class ImplementationOfIList
    {
        public int CountSpecialCharacters(IList<char> specialCharacters)
        {
            specialCharacters.Add('~');
            specialCharacters.Add('@');

            specialCharacters.Insert(0, '$');
           
            var count = 0;
            foreach (char c in specialCharacters)
            {
                count++;
            }

            return specialCharacters.IndexOf('$').Equals(0) ? count : 0;
        }

        public int CountSpecialCharactersArray(IList<char> specialCharacters)
        {           
            var count = 0;
            foreach (char c in specialCharacters)
            {
                count++;
            }

            return count;
        }
    }
}
