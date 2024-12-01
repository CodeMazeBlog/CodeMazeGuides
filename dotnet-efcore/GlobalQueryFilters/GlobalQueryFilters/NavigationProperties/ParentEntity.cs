namespace GlobalQueryFilters;

public sealed class ParentEntity(IEnumerable<ChildEntity> children)
{
    public Guid Id { get; private set; }
    public bool IsDeleted { get; set; }
    public IEnumerable<ChildEntity> Children { get; private set; } = children;
    
    private ParentEntity() : this(null!) { } // ctor for EF
}
