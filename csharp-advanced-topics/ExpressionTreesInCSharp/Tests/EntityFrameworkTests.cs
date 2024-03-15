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
}
