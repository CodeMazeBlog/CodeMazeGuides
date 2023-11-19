using Dapper;
using Microsoft.Data.SqlClient;

namespace ReturnInsertedIdentityWithDapper;

public static class SetUp
{
    public static void CreateTable(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var createTableSql = """
            CREATE TABLE Students (Id INT IDENTITY(1,1) PRIMARY KEY, 
            Surname VARCHAR(255), 
            Firstname VARCHAR(255))
            """;

        connection.Execute(createTableSql);

        connection.Close();
    }
}