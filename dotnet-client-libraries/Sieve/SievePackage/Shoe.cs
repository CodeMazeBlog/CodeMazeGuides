using Sieve.Attributes;

namespace SievePackage;
public class Shoe
{
    public required string Name { get; set; }

    [Sieve(CanFilter = true)]
    public required string Category { get; set; }

    [Sieve(CanFilter = true)]
    public required string Brand { get; set; }

    [Sieve(CanSort = true)]
    public decimal Price { get; set; }

    [Sieve(CanSort = true)]
    public decimal Rating { get; set; }
}
