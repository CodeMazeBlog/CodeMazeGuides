namespace SortedSetInCSharp
{
    public class SortedSetMethods
    {
        public SortedSet<string> ProgrammingLanguages() 
        { 
            var languages = new SortedSet<string>(); 

            languages.Add("C"); 
            languages.Add("C++"); 
            languages.Add("C#"); 
            languages.Add("Java"); 
            languages.Add("Scala"); 
            languages.Add("TypeScript"); 
            languages.Add("Python"); 
            languages.Add("JavaScript"); 
            languages.Add("Rust");
            
            return languages;
        }

        public SortedSet<string> RemoveElement(SortedSet<string> sortedSet, string valueToRemove)
        {
            sortedSet.Remove(valueToRemove);

            return sortedSet;
        }
    }
}
