using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public IEnumerable<User> FilterWithFunc(Func<User, bool> predicate)
    {
        return _dbContext.Users.Where(predicate);
    }

    public IQueryable<User> FilterWithExpression(Expression<Func<User, bool>> predicate)
    {
        return _dbContext.Users.Where(predicate);
    }
}
