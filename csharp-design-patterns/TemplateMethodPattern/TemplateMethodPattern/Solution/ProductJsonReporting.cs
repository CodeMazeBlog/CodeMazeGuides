namespace TemplateMethodPattern.Solution;

public class ProductJsonReporting : ProductReportingBase
{
    protected override string Transform(Product[] products) 
        => "JSON output";
}