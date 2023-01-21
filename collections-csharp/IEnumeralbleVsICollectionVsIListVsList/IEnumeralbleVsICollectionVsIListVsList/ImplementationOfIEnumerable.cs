using System.Collections;

namespace IEnumeralbleVsICollectionVsIListVsList
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

        public IEnumerable<int> FilterNumbers(List<int> numbers)
        {
            int total = 0;
            foreach(int num in numbers)
            {
                if(num > 2)
                {
                    total += num;
                    yield return total;
                }   
            }
        }
    }
}
