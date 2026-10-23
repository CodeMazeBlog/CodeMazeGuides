using IEnumerableCSharp;

Book[] books =
[
    new("Anna Karenina", "Leo Tolstoy"),
    new("To Kill a Mockingbird", "Harper Lee"),
    new("The Great Gatsby", "F. Scott Fitzgerald"),
    new("One Hundred Years of Solitude", "Gabriel García Márquez"),
    new("A Passage to India", "E.M. Forster")
];

var library = new Library(books);

foreach (var book in library)
{
    Console.WriteLine($"Book: {book.Name}, Author: {book.Author}");
}

var genericLibrary = new GenericLibrary(books);

var tolstoy = genericLibrary.Where(book => book.Author == "Leo Tolstoy");

foreach (var book in tolstoy)
{
    Console.WriteLine($"By Tolstoy: {book.Name}");
}
