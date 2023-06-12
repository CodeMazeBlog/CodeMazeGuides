namespace IEnumerableVsICollectionVsIListVsList
{
    public class ImplementationOfICollection
    {
        public int CountSpecialCharacters(ICollection<char> specialCharacters)
        {
            specialCharacters.Add('~');
            specialCharacters.Add('!');

            var count = 0;
            foreach (char c in specialCharacters)
            {
                count++;
            }

            return count;
        }
    }
}
