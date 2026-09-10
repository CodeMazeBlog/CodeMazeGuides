using Entities.Models;
using System.Linq;

namespace Repository.Extensions;

public static class RepositoryOwnerExtensions
{
    public static IQueryable<Owner> Search(this IQueryable<Owner> owners, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return owners;

        var term = searchTerm.Trim();

        return owners.Where(o => o.Name.Contains(term) || o.Address.Contains(term));
    }
}
