using Dapper;
using System.Data;

namespace PassingOutputParametersToStoredProcedures
{
    public static class BusinessLogic
    {
        public static dynamic InsertNewDeveloper(string Name, string Language)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", Name);
            parameters.Add("Language", Language);
            parameters.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

            var result = DataAccess.ExecuteStoredProcedure(parameters);

            return result;
        }
    }
}
