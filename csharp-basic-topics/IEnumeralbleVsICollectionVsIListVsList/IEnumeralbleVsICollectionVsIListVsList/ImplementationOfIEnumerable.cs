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
    }
}
