namespace TemplateMethodPattern.Solution;

public class ProductPdfReporting : ProductReportingBase
{
    protected override string Transform(Product[] products) 
        => "PDF output";

    protected override string GetRecipient()
        => "pdf recipient";
}