using Microsoft.EntityFrameworkCore;

namespace EFCoreComplexTypes;

public class ComplexTypesDBService()
{
    private readonly AppDbContext _context = new();
    public async Task SaveComplexType()
    {
        var user = new User()
        {
            UserName = "Luther",
            Address = new Address("Slessor Way", "Bendel", "Rivers", "504103", "Nigeria")
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetComplexTypeOwningEntity(int id)
        => await _context.Users.FirstAsync(user => user.Id == id);

    public async Task<Address> GetComplexTypeFromOwningEntity(int id)
    {
        var query = await _context.Users
            .Select(u => new { u.Id, u.Address })
            .SingleAsync(user => user.Id == id);

        return query.Address;
    }
}