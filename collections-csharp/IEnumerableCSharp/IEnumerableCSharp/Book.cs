namespace IEnumerableCSharp
{
    public class Book
    {
        public Book(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string Name { get; set; }
        public string Author { get; set; }
    }
}
