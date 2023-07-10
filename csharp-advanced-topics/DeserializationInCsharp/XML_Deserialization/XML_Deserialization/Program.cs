using System.Xml.Serialization;

namespace XML_Deserialization
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            var xmlData = "<Person>" +
                          "<Name>John Doe</Name>" +
                          "<Age>30</Age>" +
                          "</Person>";

            Person person = DeserializeXmlData(xmlData);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }

        public static Person DeserializeXmlData(string xmlData)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                using (StringReader reader = new StringReader(xmlData))
                {
                    return (Person)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}