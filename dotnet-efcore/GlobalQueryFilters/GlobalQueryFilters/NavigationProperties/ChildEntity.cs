namespace GlobalQueryFilters;

public sealed class ChildEntity
{
    public Guid Id { get; private set; }
    public ParentEntity Parent { get; private set; } = null!;
}
