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

        Assert.Equal(result?.ReplaceLineEndings(), _expectedResults["Book2"].ReplaceLineEndings());
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodes_ThenReturnBooksWithPriceLowerThan50()
    {
        var expected = _expectedResults
            .Where(pair => pair.Key is "Book1" or "Book3")
            .Select(pair => pair.Value.ReplaceLineEndings())
            .ToList();

        var result = XmlNodesSelector.SelectBooks(_document.DocumentElement!)
            .Select(x => x.ReplaceLineEndings())
            .ToList();

        Assert.Equal(result, expected);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodesUsingNamespaces_ThenReturnBookElementWithNamespace()
    {
        var expected =
            _expectedResults
            .Where(pair => pair.Key is "Book4")
            .Select(pair => pair.Value.ReplaceLineEndings())
            .ToList();

        var result = XmlNodesSelector.SelectBooksUsingNamespaces(_document)
            .Select(x => x.ReplaceLineEndings())
            .ToList();

        Assert.Equal(result, expected);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectSingleNodeMatchesNothing_ThenReturnsNull()
    {
        var node = _document.DocumentElement!.SelectSingleNode("//catalog/book[price>1000]");

        Assert.Null(node);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectNodesMatchesNothing_ThenReturnsAnEmptyList()
    {
        var nodes = _document.DocumentElement!.SelectNodes("//catalog/book[price>1000]");

        Assert.NotNull(nodes);
        Assert.Equal(0, nodes.Count);
    }

    [Fact]
    public void GivenABookInADefaultNamespace_WhenQueryingWithAnUnprefixedName_ThenReturnsThreeOfTheFourBooks()
    {
        var nodes = _document.DocumentElement!.SelectNodes("//catalog/book");

        Assert.NotNull(nodes);
        Assert.Equal(3, nodes.Count);
    }

    [Fact]
    public void GivenAnXDocument_WhenSelectingWithXPathSelectElements_ThenReturnsTheSameBooksAsSelectNodes()
    {
        var expected = XmlNodesSelector.SelectBooks(_document.DocumentElement!)
            .Select(x => x.ReplaceLineEndings())
            .ToList();

        var result = XmlNodesSelector.SelectBooksWithLinqToXml(XDocument.Load("BooksCatalog.xml"))
            .Select(x => x.ReplaceLineEndings())
            .ToList();

        Assert.Equal(expected, result);
    }
}
