using ExpressionTreesInCSharp.EntityFramework;

namespace Tests;
public class EntityFrameworkTests
{
    [Fact]
    public void GivenAUserDbContext_WhenListedUsers_ThenShouldUseCorrectQuery()
    {
        var efSqlite = new EntityFrameworkSqlite();

        var query = efSqlite.GetUsersListQuery();

        var expectedQuery = """
            SELECT "u"."Id", "u"."Age", "u"."Name"
            FROM "Users" AS "u"
            """;

        Assert.Equal(expectedQuery, query);
    }

    [Fact]
    public void GivenAUserDbContext_WhenListedUsersWithFilters_ThenShouldUseCorrectQuery()
    {
        var efSqlite = new EntityFrameworkSqlite();

        var query = efSqlite.GetWhereQuery();

        var expectedQuery = """
            SELECT "u"."Id", "u"."Age", "u"."Name"
            FROM "Users" AS "u"
            WHERE "u"."Age" > 20
            """;

        Assert.Equal(expectedQuery, query);
    }

    [Fact]
    public void GivenAFuncPredicate_WhenFiltering_ThenTheQueryLeavesEntityFramework()
    {
        var efSqlite = new EntityFrameworkSqlite();

        var withFunc = efSqlite.FilterWithFunc(x => x.Age > 20);
        var withExpression = efSqlite.FilterWithExpression(x => x.Age > 20);

        Assert.False(withFunc is IQueryable<User>);
        Assert.True(withExpression is IQueryable<User>);
    }
}
