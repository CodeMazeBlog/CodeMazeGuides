using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingOutputParametersToStoredProcedures
{
    public static class BusinessLogic
    {
        public static dynamic InsertNewDeveloper(string Name, string Language)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", Name);
            parameters.Add("Language", Language);
            parameters.Add("Id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
            parameters.Add("Message", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 200);
            var result = DataAccess.ExecuteStoredProcedure(parameters);
            return result;
        }
    }
}
