using Dapper;
using Microsoft.Data.SqlClient;

namespace ReturnInsertedIdentityWithDapper;

public static class Methods
{
    public static int UseOfOutputInserted(string connectionString, Student newStudent)
    {
        using var dbConnection = new SqlConnection(connectionString);

        dbConnection.Open();

        var lastInsertedId = dbConnection.QuerySingle<int>(
            """
            INSERT INTO Students (Firstname, Surname) 
            OUTPUT INSERTED.Id 
            VALUES (@Firstname, @Surname);
            """,
            newStudent
        );

        dbConnection.Close();

        return lastInsertedId;
    }

    public static int UseOfScopeIdentity(string connectionString, Student newStudent)
    {
        using var dbConnection = new SqlConnection(connectionString);

        dbConnection.Open();

        var lastInsertedId = dbConnection.QuerySingle<int>(
            """
            INSERT INTO Students (Firstname, Surname) 
            VALUES (@Firstname, @Surname) 
            SELECT CAST(SCOPE_IDENTITY() AS INT);
            """,
            newStudent
        );

        dbConnection.Close();

        return lastInsertedId;
    }
}