namespace GlobalQueryFilters;

public sealed class SoftDeleteEntity(IEnumerable<Child> children)
{
    public Guid Id { get; private set; }
    public bool IsDeleted { get; set; }
    public IEnumerable<Child> Children { get; private set; } = children;
    
    private SoftDeleteEntity() : this(null!){} // ctor for EF
}