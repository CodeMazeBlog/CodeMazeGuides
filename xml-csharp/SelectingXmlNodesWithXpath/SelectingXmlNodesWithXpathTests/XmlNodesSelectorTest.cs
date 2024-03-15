namespace SelectingXmlNodesWithXpathTests;

public class XmlNodesSelectorTest
{
    private readonly XmlDocument _document;
    private readonly Dictionary<string, string> _expectedResults;

    public XmlNodesSelectorTest()
    {
        _document = new XmlDocument();
        _document.Load("BooksCatalog.xml");

        _expectedResults = new Dictionary<string, string>()
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
        var result = XmlNodesSelector.SelectSingleBook(_document.DocumentElement!);

        Assert.Equal(result, _expectedResults["Book2"]);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodes_ThenReturnBooksWithPriceLowerThan50()
    {
        var expected = _expectedResults
            .Where(pair => pair.Key is "Book1" or "Book3")
            .Select(pair => pair.Value)
            .ToList();

        var result = XmlNodesSelector.SelectBooks(_document.DocumentElement!);

        Assert.Equal(result, expected);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodesUsingNamespaces_ThenReturnBookElementWithNamespace()
    {
        var expected =
            _expectedResults
            .Where(pair => pair.Key is "Book4")
            .Select(pair => pair.Value)
            .ToList();

        var result = XmlNodesSelector.SelectBooksUsingNamespaces(_document);

        Assert.Equal(result, expected);
    }
}