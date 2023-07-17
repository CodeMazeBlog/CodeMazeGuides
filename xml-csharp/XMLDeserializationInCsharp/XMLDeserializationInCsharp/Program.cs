using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{

    public class Program
    {
        static void Main(string[] args)
        {
            #region Deserialization_Of_Class
            #region Simple Deserialization
            var xmlData = @"<Person>
                                <Name>John Doe</Name>
                                <Age>30</Age>
                            </Person>";


            var person = DeserializeXmlData<Person>(xmlData);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            #endregion

            #region Complex Deserialization
            var complexXML = @"<Library>
                            <Books>
                                <Book>
                                    <Title>Book 1</Title>
                                    <Author>Author 1</Author>
                                </Book>
                                <Book>
                                    <Title>Book 2</Title>
                                    <Author>Author 2</Author>
                                </Book>
                            </Books>
                          </Library>";

            var library = DeserializeXmlData<Library>(complexXML);
            foreach (Book book in library.Books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
            #endregion
            #endregion


            #region Deserialization_Of_Records

            //Simple Deserialization
            var personRecord = DeserializeXmlData<PersonRecord>(xmlData);
            Console.WriteLine($"Name: {personRecord.Name}, Age: {personRecord.Age}");

            //Complex Deserialization
            var libraryRecord = DeserializeXmlData<LibraryRecord>(xmlData);
            foreach (Book book in library.Books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
            #endregion
        }

        #region Deserialization Method
        public static T DeserializeXmlData<T>(string xmlData)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlData);
            return (T)serializer.Deserialize(reader);
        }
        #endregion
    }
}