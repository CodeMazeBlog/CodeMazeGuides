namespace SelectingXmlNodesWithXpathTests;

public class XmlNodesSelectorTest
{
    private XmlDocument Document { get; }
    private Dictionary<string, string> ExpectedResults { get; }

    public XmlNodesSelectorTest()
    {
        Document = new XmlDocument();
        Document.Load("BooksCatalog.xml");

        ExpectedResults = new Dictionary<string, string>()
        {
            {
                "Book1",
                """
                <book id="1">
                  <author>King, Stephen</author>
                  <title>IT</title>
                  <genre>Horror</genre>
                  <price>40.00</price>
                </book>
                """
            },
            {
                "Book2",
                """
                <book id="2">
                  <author>Assis, Machado De</author>
                  <title>Dom Casmurro</title>
                  <genre>Romance</genre>
                  <price>50.00</price>
                </book>
                """
            },
            {
                "Book3",
                """
                <book id="3">
                  <author>Calaprice, Alice; Lipscombe, Trevor</author>
                  <title>Albert Einstein: A Biography</title>
                  <genre>Biography</genre>
                  <price>30.00</price>
                </book>
                """
            },
            {
                "Book4",
                """
                <book id="4" xmlns="urn:example-schema">
                  <author>Fowler, Martin; Beck, Kent</author>
                  <title>Refactoring: Improving the design of existing code</title>
                  <genre>Scientific</genre>
                  <price>60.00</price>
                </book>
                """
            }
        };
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingASingleNode_ThenReturnsTheSecondPosition()
    {
        var result = XmlNodesSelector.SelectSingleBook(Document.DocumentElement!);

        Assert.Equal(result, ExpectedResults["Book2"]);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodes_ThenReturnBooksWithPriceLowerThan50()
    {
        var expected = ExpectedResults
            .Where(pair => pair.Key is "Book1" or "Book3")
            .Select(pair => pair.Value)
            .ToList();

        var result = XmlNodesSelector.SelectBooks(Document.DocumentElement!);

        Assert.Equal(result, expected);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodesUsingNamespaces_ThenReturnBookElementWithNamespace()
    {
        var expected =
            ExpectedResults
            .Where(pair => pair.Key is "Book4")
            .Select(pair => pair.Value)
            .ToList();

        var result = XmlNodesSelector.SelectBooksUsingNamespaces(Document);

        Assert.Equal(result, expected);
    }
}