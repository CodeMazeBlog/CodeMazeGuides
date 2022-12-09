using ExecuteStoredProceduresInEFCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ExecuteStoredProceduresInEFCore
{
    public static class UpdateMethods
    {
        public static int UpdateStudentMarkSql(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSql($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }

        public async static Task<int> UpdateStudentMarkSqlAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlAsync($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }

        public static int UpdateStudentMarkSqlRaw(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSqlRaw("dbo.UpdateStudentMark @Id, @Mark",
                new SqlParameter("@Id", id),
                new SqlParameter("@Mark", mark));
        }

        public async static Task<int> UpdateStudentMarkSqlRawAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlRawAsync("dbo.UpdateStudentMark @Id, @Mark",
                new SqlParameter("@Id", id),
                new SqlParameter("@Mark", mark));
        }

        public static int UpdateStudentMarkSqlInterpolated(AppDbContext context, int id, int mark)
        {
            return context.Database.ExecuteSqlInterpolated($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }
        public async static Task<int> UpdateStudentMarkSqlInterpolatedAsync(AppDbContext context, int id, int mark)
        {
            return await context.Database.ExecuteSqlInterpolatedAsync($"UpdateStudentMark @Id={id}, @Mark={mark}");
        }

        public static int UpdateStudentMarkSqlDynamic(AppDbContext context, int id, int mark)
        {
            var field1 = "@Id";
            var field2 = "@Mark";

            return context.Database.ExecuteSql($"UpdateStudentMark {field1}={id}, {field2}={mark}");
        }

        public static int UpdateStudentMarkSqlRawDynamic(AppDbContext context, int id, int mark)
        {
            var field1 = "@Id";
            var field2 = "@Mark";

            return context.Database.ExecuteSqlRaw($"dbo.UpdateStudentMark {field1} = @Id, {field2}=@Mark",
                new SqlParameter("@Id", id),
                new SqlParameter("@Mark", mark));
        }

        public static int UpdateStudentMarkWithReturnValueSqlRaw(AppDbContext context, int id, int mark)
        {
            var avgMarkParameter = new SqlParameter()
            {
                ParameterName = "AvgMark",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            context.Database.ExecuteSqlRaw("dbo.UpdateStudentMarkWithReturnValue @Id, @Mark, @AvgMark OUTPUT",
                new SqlParameter("@Id", id),
                new SqlParameter("@Mark", mark),
                avgMarkParameter);

            return (int)avgMarkParameter.Value;
        }
    }
}
