using System.Xml.Serialization;
using XMLDeserializationInCsharp;

var personSerializer = new XmlSerializer(typeof(Person));

using (var reader = new StreamReader("person.xml"))
{
    var person = (Person?)personSerializer.Deserialize(reader);
    if (person != null)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    }
}

var librarySerializer = new XmlSerializer(typeof(Library));

using (var reader = new StreamReader("library.xml"))
{
    var library = (Library?)librarySerializer.Deserialize(reader);
    if (library != null)
    {
        foreach (Book book in library.Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}

//Simple Deserialization
var personXML = """
    <PersonRecord>
        <Name>John Wick</Name>
        <Age>35</Age>
    </PersonRecord>
    """;
var personRecord = XmlDeserializer.DeserializeXmlData<PersonRecord>(personXML);
if (personRecord != null)
{
    Console.WriteLine($"Name: {personRecord.Name}, Age: {personRecord.Age}");
}

//Complex Deserialization
var libraryXML = """
    <LibraryRecord>
        <Books>
            <BookRecord>
                <Title>Book 3</Title>
                <Author>Author 3</Author>
            </BookRecord>
            <BookRecord>
                <Title>Book 4</Title>
                <Author>Author 4</Author>
            </BookRecord>
        </Books>
    </LibraryRecord>
    """;

var libraryRecord = XmlDeserializer.DeserializeXmlData<LibraryRecord>(libraryXML);
if (libraryRecord != null)
{
    foreach (BookRecord book in libraryRecord.Books)
    {
        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
    }
}
