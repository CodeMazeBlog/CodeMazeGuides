namespace DynamicDbContextSwitching;

public class SecondaryRepository : IRepository
{
    private readonly SecondaryDbContext _secondaryDbContext;

    public SecondaryRepository(SecondaryDbContext secondaryDbContext)
    {
        _secondaryDbContext = secondaryDbContext;
    }

    public async Task<bool> TestConnection()
    {
        return await _secondaryDbContext.Database.CanConnectAsync();
    }
}