using System.Collections;

namespace IEnumerableVsICollectionVsIListVsList
{
    public class ImplementationOfIEnumerable
    {
        public int CountSpecialCharacters(IEnumerable<char> specialCharacters)
        {
            var count = 0;
            foreach(char c in specialCharacters)
            {
                count++;
            }

            return count;
        }

        public IEnumerable<int> GetEvenNumberUpToTen()
        {
            yield return 0;
            yield return 2;
            yield return 4;
            yield return 6;
            yield return 8;
            yield return 10;
        }
    }
}
