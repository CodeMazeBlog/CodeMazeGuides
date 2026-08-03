namespace TemplateMethodPattern.Solution;

public class ProductXmlReporting : ProductReportingBase
{
    protected override string Transform(Product[] products) 
        => "XML output";
}