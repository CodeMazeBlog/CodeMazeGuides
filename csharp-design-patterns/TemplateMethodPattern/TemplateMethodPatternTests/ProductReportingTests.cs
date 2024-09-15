using System.Text;
using TemplateMethodPattern.Solution;

namespace TemplateMethodPatternTests;

public class ProductReportingTests
{
    private readonly StringBuilder _stringBuilder = new();

    public ProductReportingTests() 
    {
        Console.SetOut(new StringWriter(_stringBuilder));
    }

    [Fact]
    public void GivenProductXmlReporting_WhenInvokeSend_ThenSendsXmlReport()
    {
        var reporting = new ProductXmlReporting();

        reporting.Send();

        var expected = """
            Sent XML output to default recipient
            
            """;

        Assert.Equal(expected.ReplaceLineEndings(), _stringBuilder.ToString().ReplaceLineEndings());
    }

    [Fact]
    public void GivenProductJsonReporting_WhenInvokeSend_ThenSendsJsonReport()
    {
        var reporting = new ProductJsonReporting();

        reporting.Send();

        var expected = """
            Sent JSON output to default recipient
            
            """;

        Assert.Equal(expected.ReplaceLineEndings(), _stringBuilder.ToString().ReplaceLineEndings());
    }

    [Fact]
    public void GivenProductPdfReporting_WhenInvokeSend_ThenSendsPdfReport()
    {
        var reporting = new ProductPdfReporting();

        reporting.Send();

        var expected = """
            Sent PDF output to pdf recipient
            
            """;

        Assert.Equal(expected.ReplaceLineEndings(), _stringBuilder.ToString().ReplaceLineEndings());
    }
}