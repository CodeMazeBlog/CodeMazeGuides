namespace GlobalQueryFilters;

public sealed class SoftDeleteEntity()
{
    public Guid Id { get; private set; }
    public bool IsDeleted { get; set; }
}