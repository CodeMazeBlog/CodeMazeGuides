using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace IEnumerableVsICollectionVsIListVsList
{
    public class ImplementationOfList
    {
        public int CountSpecialCharacters(List<char> specialCharacters)
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
