namespace TemplateMethodPattern.Solution;

public abstract class ProductReportingBase
{
    public void Send()
    {
        var products = GetProducts();

        var output = Transform(products);

        var recipient = GetRecipient();

        SendEmail(output, recipient);
    }

    private Product[] GetProducts()
        => [.. ProductService.GetProducts().OrderBy(e => e.Name)];

    protected abstract string Transform(Product[] products);

    protected virtual string GetRecipient()
        => "default recipient";

    private void SendEmail(string output, string recipient)
        => Console.WriteLine($"Sent {output} to {recipient}");
}