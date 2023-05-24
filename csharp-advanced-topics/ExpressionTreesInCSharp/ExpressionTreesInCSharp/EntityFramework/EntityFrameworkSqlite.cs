using Microsoft.EntityFrameworkCore;

namespace ExpressionTreesInCSharp.EntityFramework;
public class EntityFrameworkSqlite
{
    private readonly UserDbContext _dbContext = new();

    public EntityFrameworkSqlite()
    {
        _dbContext.Database.EnsureCreated();
    }

    public string GetUsersListQuery()
    {
        var listQuery = _dbContext.Users
            .ToQueryString();

        return listQuery;
    }

    public string GetWhereQuery()
    {
        var whereQuery = _dbContext.Users
            .Where(x => x.Age > 20)
            .ToQueryString();

        return whereQuery;
    }
}