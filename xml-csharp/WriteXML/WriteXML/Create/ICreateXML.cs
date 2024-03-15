namespace WriteXML.Create
{
    public interface ICreateXml
    {
        string CreateSimpleXml(Person person);
        string CreateSimpleXmlWithAttributes(Person person);
        string CreateXmlWithNamespace(Person person);
        string CreateXmlWithThreeNamespaces(Person person);

        string CreateAnArrayOfPeople(Person[] people);
    }
}