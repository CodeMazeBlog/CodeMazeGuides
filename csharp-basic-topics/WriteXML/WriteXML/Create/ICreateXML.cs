namespace WriteXML.Create
{
    public interface ICreateXML
    {
        string CreateSimpleXML(Person person);
        string CreateSimpleXMLWithAttributes(Person person);
        string CreateXMLWithNamespace(Person person);
        string CreateXMLWithNamespace2(Person person);

        string CreateAnArrayOfPeople(Person[] people);
    }
}