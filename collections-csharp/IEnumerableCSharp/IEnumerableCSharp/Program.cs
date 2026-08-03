namespace IEnumerableCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = new Book[5]
            {
                new Book("Anna Karenina", "Leo Tolstoy"),
                new Book("To Kill a Mockingbird", "Harper Lee"),
                new Book("The Great Gatsby", "F. Scott Fitzgerald"),
                new Book("One Hundred Years of Solitude", "Gabriel García Márquez"),
                new Book("A Passage to India", "E.M. Forster")
            };

            var library = new Library(books);

            foreach (var book in library)
            {
                Console.WriteLine($"Book: {book.Name}, Author: {book.Author}");
            }
        }
    }
}