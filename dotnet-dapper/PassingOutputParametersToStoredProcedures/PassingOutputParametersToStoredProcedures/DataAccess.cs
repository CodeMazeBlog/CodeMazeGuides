using Dapper;
using Microsoft.Data.SqlClient;

namespace PassingOutputParametersToStoredProcedures
{
    public static class DataAccess
    {

        static string ConnectionString= "";

        public static dynamic ExecuteStoredProcedure(DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("DeveloperInsert", parameters, commandType: System.Data.CommandType.StoredProcedure);
                var message = parameters.Get<string>("Message");
                var id = parameters.Get<int?>("Id");

                if (id != null)
                {
                    return id;
                }
                else
                {
                    return message;
                }
            }
        }
    }
}
