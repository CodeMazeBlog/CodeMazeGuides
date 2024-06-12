using Microsoft.EntityFrameworkCore;

namespace EFCoreComplexTypes;

public class ComplexTypesDBService()
{
    private readonly AppDbContext _context = new();
    public async void SaveComplexType()
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
        => await _context.Users
        .Where(user => user.Id == id)
        .Select(u => u.Address).SingleAsync();
}