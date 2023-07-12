using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{
    #region Simple XML
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    #endregion

    #region Complex XML
    [XmlRoot("Library")]
    public class Library
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<Book> Books { get; set; }
    }

    public class Book
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Author")]
        public string Author { get; set; }
    }
    #endregion

    public class Program
    {
        static void Main(string[] args)
        {
            #region Simple Deserialization
            var xmlData = "<Person>" +
                        "<Name>John Doe</Name>" +
                        "<Age>30</Age>" +
                        "</Person>";


            var person = DeserializeXmlData<Person>(xmlData);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            #endregion

            #region Complex Deserialization
            var complexXML = "<Library>" +
                             "<Books><Book>" +
                             "<Title>The Catcher in the Rye</Title>" +
                             "<Author>J.D. Salinger</Author>" +
                             "</Book>" +
                             "<Book>" +
                             "<Title>To Kill a Mockingbird</Title>" +
                             "<Author>Harper Lee</Author>" +
                             "</Book>" +
                             "</Books>" +
                             "</Library>";

            var library=DeserializeXmlData<Library>(complexXML);
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
            using (var reader = new StringReader(xmlData))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        #endregion
    }
}