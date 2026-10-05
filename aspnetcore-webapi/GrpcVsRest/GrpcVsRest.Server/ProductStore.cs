namespace GrpcVsRest.Server;

public record ProductDto(int Id, string Name, string Category, double Price, int Stock);

public class ProductStore
{
    private static readonly string[] Items =
        ["Mechanical Keyboard", "Wireless Mouse", "USB-C Hub", "Laptop Stand", "Webcam"];

    private static readonly string[] Categories = ["Peripherals", "Accessories", "Video"];

    public IReadOnlyList<ProductDto> All { get; } = Enumerable.Range(1, 100)
        .Select(id => new ProductDto(
            id,
            $"{Items[id % Items.Length]} {id}",
            Categories[id % Categories.Length],
            Math.Round(id + 0.99, 2),
            id * 3))
        .ToList();

    public ProductDto? Find(int id) => All.FirstOrDefault(p => p.Id == id);
}
