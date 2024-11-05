namespace GlobalQueryFilters;

public sealed class Child
{
    public Guid Id { get; private set; }
    public SoftDeleteEntity Parent { get; private set; }
}