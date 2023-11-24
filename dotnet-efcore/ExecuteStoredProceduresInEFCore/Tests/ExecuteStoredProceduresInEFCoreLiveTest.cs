using ExecuteStoredProceduresInEFCore;
using ExecuteStoredProceduresInEFCore.Models;
using Microsoft.Data.SqlClient;
using System;
using Xunit;

namespace Tests
{
    public class ExecuteStoredProceduresInEFCoreLiveTest
    {
        private readonly AppDbContext context;

        public ExecuteStoredProceduresInEFCoreLiveTest()
        {
            context = new AppDbContext();
            SeedManager.SeedData(context).Wait();
        }

        [Fact]
        public void WhenFindStudentsExecuteSql_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSql(context, "100");

            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlRaw_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlRaw(context, "100");

            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlRawUnsafe_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlRawUnsafe(context, "100");

            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlRawUnsafeSqlInjection_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlRawUnsafe(context, 
                @"xyz'; UPDATE Students SET Name = 'Student 000' WHERE Id = 1; SELECT '");

            Assert.True(results?.Count == 0);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlInterpolated_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlInterpolated(context, "100");

            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExtendedFromSqlRaw_ThenFail()
        {
            Assert.Throws<InvalidOperationException>(
                () => FindMethods.FindStudentsAltFromSqlRaw(context, "100")
            );
        }

        [Fact]
        public void WhenFindStudentsAltFromSqlInterpolated_ThenFail()
        {
            Assert.Throws<InvalidOperationException>(
                () => FindMethods.FindStudentsAltFromSqlInterpolated(context, "100")
            );
        }

        [Fact]
        public void WhenUpdateStudentMarkSql_ThenSuccess()
        {
            var results = UpdateMethods.UpdateStudentMarkSql(context, 1, 777);

            Assert.True(results == 1);
        }

        [Fact]
        public async void WhenUpdateStudentMarkSqlAsync_ThenSuccess()
        {
            var results = await UpdateMethods.UpdateStudentMarkSqlAsync(context, 1, 777);

            Assert.True(results == 1);
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlRaw_ThenSuccess()
        {
            var results = UpdateMethods.UpdateStudentMarkSqlRaw(context, 1, 888);

            Assert.True(results == 1);
        }
        [Fact]
        public async void WhenUpdateStudentMarkSqlRawAsync_ThenSuccess()
        {
            var results = await UpdateMethods.UpdateStudentMarkSqlRawAsync(context, 1, 888);

            Assert.True(results == 1);
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlInterpolated_ThenSuccess()
        {
            var results = UpdateMethods.UpdateStudentMarkSqlInterpolated(context, 1, 999);

            Assert.True(results == 1);
        }
        [Fact]
        public async void WhenUpdateStudentMarkSqlInterpolatedAsync_ThenSuccess()
        {
            var results = await UpdateMethods.UpdateStudentMarkSqlInterpolatedAsync(context, 1, 999);

            Assert.True(results == 1);
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlDynamic_ThenFail()
        {
            Assert.Throws<SqlException>(
                () => UpdateMethods.UpdateStudentMarkSqlDynamic(context, 1, 666)
            );
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlRawDynamic_ThenSuccess()
        {
            var results = UpdateMethods.UpdateStudentMarkSqlRawDynamic(context, 1, 666);

            Assert.True(results == 1);
        }

        [Fact]
        public void WhenFindStudentsFromSqlAndLinq_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlAndLinq(context, "100");

            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsFromSqlAndUpdateMarks_ThenSuccess()
        {
            var results = FindMethods.FindStudentsFromSqlAndUpdateMarks(context, "100");

            Assert.True(results == 9);
        }

        [Fact]
        public void WhenUpdateStudentMarkWithReturnValueSqlRaw_ThenSuccess()
        {
            var results = UpdateMethods.UpdateStudentMarkWithReturnValueSqlRaw(context, 1, 999);

            Assert.True(results > 1);
        }
    }
}