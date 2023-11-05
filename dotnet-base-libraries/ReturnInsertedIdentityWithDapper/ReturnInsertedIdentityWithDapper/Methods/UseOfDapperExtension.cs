using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace ReturnInsertedIdentityWithDapper;

public partial class Methods
{
    public static int UseOfDapperExtension(string connectionString, Student newStudent)
    {
        using var dbConnection = new SqlConnection(connectionString);

        dbConnection.Open();

        var lastInsertedId = dbConnection.Insert(newStudent);

        dbConnection.Close();

        return (int)lastInsertedId;
    }
}