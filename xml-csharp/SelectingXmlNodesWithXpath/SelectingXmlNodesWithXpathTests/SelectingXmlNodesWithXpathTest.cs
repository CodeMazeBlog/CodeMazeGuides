using System.Xml;

namespace SelectingXmlNodesWithXpathTests;

public class SelectingXmlNodesWithXpathTest
{
    private XmlDocument Document { get; set; }
    private Dictionary<string, string> ExpectedResults { get; set; }

    public SelectingXmlNodesWithXpathTest()
    {
        Document = new XmlDocument();
        Document.Load("BooksCatalog.xml");

        ExpectedResults = new Dictionary<string, string>()
        {
            {
                "Book1",
                """<book id="1">""" +
                    """<author>King, Stephen</author>""" +
                    """<title>IT</title>""" +
                    """<genre>Horror</genre>""" +
                    """<price>40.00</price>""" +
                """</book>"""
            },
            {
                "Book2",
                """<book id="2">""" +
                    """<author>Assis, Machado De</author>""" +
                    """<title>Dom Casmurro</title>""" +
                    """<genre>Romance</genre>""" +
                    """<price>50.00</price>""" +
                """</book>"""
            },
            {
                "Book3",
                """<book id="3">""" +
                    """<author>Calaprice, Alice; Lipscombe, Trevor</author>""" +
                    """<title>Albert Einstein: A Biography</title>""" +
                    """<genre>Biography</genre>""" +
                    """<price>30.00</price>""" +
                """</book>"""
            },
            {
                "Book4",
                """<book id="4" xmlns="urn:example-schema">""" +
                    """<author>Fowler, Martin; Beck, Kent</author>""" +
                    """<title>Refactoring: Improving the design of existing code</title>""" +
                    """<genre>Scientific</genre>""" +
                    """<price>60.00</price>""" +
                """</book>"""
            }
        };
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingASingleNode_ThenReturnsTheSecondPosition()
    {
        var node = Document.SelectSingleNode("//catalog/book[position()=2]");

        Assert.Equal(node.OuterXml, ExpectedResults["Book2"]);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodes_ThenReturnBooksWithPriceLowerThan50()
    {
        var nodes = Document
            .SelectNodes("//catalog/book[price<50.00]");

        var outerXmls = nodes
            .Cast<XmlNode>()
            .Select(node => node.OuterXml);

        var expected = ExpectedResults
            .Where(pair => pair.Key == "Book1" || pair.Key == "Book3")
            .Select(pair => pair.Value);

        Assert.Equal(outerXmls,expected);
    }

    [Fact]
    public void GivenAnXmlFile_WhenSelectingNodesUsingNamespaces_ThenReturnBookElementWithNamespace()
    {
        var nsmgr = new XmlNamespaceManager(Document.NameTable);
        nsmgr.AddNamespace("ex", "urn:example-schema");

        var nodes = Document
            .SelectNodes("descendant::ex:book", nsmgr);

        var outerXmls = nodes
            .Cast<XmlNode>()
            .Select(node => node.OuterXml);

        Assert.Equal(outerXmls,
            ExpectedResults
            .Where(pair => pair.Key == "Book4")
            .Select(pair => pair.Value));
    }
}