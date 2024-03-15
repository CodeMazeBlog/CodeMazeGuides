namespace DynamicDbContextSwitching;

public class PrimaryRepository : IRepository
{
    private readonly PrimaryDbContext _primaryDbContext;

    public PrimaryRepository(PrimaryDbContext primaryDbContext)
    {
        _primaryDbContext = primaryDbContext;
    }

    public async Task<bool> TestConnection()
    {
        return await _primaryDbContext.Database.CanConnectAsync();
    }
}

public interface IRepository
{
    Task<bool> TestConnection();
}