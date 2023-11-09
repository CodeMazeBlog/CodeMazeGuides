using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace XMLDeserializationInCsharp
{
	public class Program
	{
		static void Main(string[] args)
		{
			var xmlData2 = """<PersonRecord> <Name>John Doe</Name> <Age>30</Age> </PersonRecord>"""; var person2 = DeserializeXmlData<PersonRecord>(xmlData2); Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");

			var xmlData = """
                            <Person>
                                <Name>John Doe</Name>
                                <Age>30</Age>
                            </Person>
                            """;

			var person = DeserializeXmlData<Person>(xmlData);
			if (person != null)
			{
				Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
			}

			var complexXML = """
                                <Library>
                                     <Books>
                                    <Book>
                                        <Title> Book 1 </Title>
                                        <Author> Author 1 </Author>
                                    </Book>
                                    <Book>
                                        <Title> Book 2 </Title>
                                        <Author> Author 2 </Author>
                                    </Book>
                                </Books>
                                </Library>
                                """;

			var library = DeserializeXmlData<Library>(complexXML);
			if (library != null)
			{
				foreach (Book book in library.Books)
				{
					Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
				}
			}

			//Simple Deserialization
			var personXML = """
                            <PersonRecord>
                                <Name>John Wick</Name>
                                <Age>35</Age>
                            </PersonRecord>
                            """;
			var personRecord = DeserializeXmlData<PersonRecord>(personXML);
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

			var libraryRecord = DeserializeXmlData<LibraryRecord>(libraryXML);
			if (libraryRecord != null)
			{
				foreach (BookRecord book in libraryRecord.Books)
				{
					Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
				}
			}
		}

		public static T? DeserializeXmlData<T>(string xmlData)
		{
			var serializer = new XmlSerializer(typeof(T));
			using var reader = new StringReader(xmlData);

			return (T?)serializer.Deserialize(reader);
		}
	}
}