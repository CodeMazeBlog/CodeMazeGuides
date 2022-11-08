using ExecuteStoredProceduresInEFCore;
using ExecuteStoredProceduresInEFCore.Models;
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
            Methods.SeedData(context).Wait();
        }

        [Fact]
        public void WhenFindStudentsExecuteSql_ThenSuccess()
        {
            var results = Methods.FindStudentsFromSql(context, "100");
            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlRaw_ThenSuccess()
        {
            var results = Methods.FindStudentsFromSqlRaw(context, "100");
            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExecuteSqlInterpolated_ThenSuccess()
        {
            var results = Methods.FindStudentsFromSqlInterpolated(context, "100");
            Assert.True(results?.Count == 9);
        }

        [Fact]
        public void WhenFindStudentsExtendedFromSqlRaw_ThenSuccess()
        {
            Assert.Throws<InvalidOperationException>(
                () => Methods.FindStudentsAltFromSqlRaw(context, "100")
            );
        }

        [Fact]
        public void WhenFindStudentsAltFromSqlInterpolated_ThenSuccess()
        {
            Assert.Throws<InvalidOperationException>(
                () => Methods.FindStudentsAltFromSqlInterpolated(context, "100")
            );
        }

        [Fact]
        public void WhenUpdateStudentMarkSql_ThenSuccess()
        {
            var results = Methods.UpdateStudentMarkSql(context, 1, 777);
            Assert.True(results == 1);
        }

        [Fact]
        public async void WhenUpdateStudentMarkSqlAsync_ThenSuccess()
        {
            var results = await Methods.UpdateStudentMarkSqlAsync(context, 1, 777);
            Assert.True(results == 1);
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlRaw_ThenSuccess()
        {
            var results = Methods.UpdateStudentMarkSqlRaw(context, 1, 888);
            Assert.True(results == 1);
        }
        [Fact]
        public async void WhenUpdateStudentMarkSqlRawAsync_ThenSuccess()
        {
            var results = await Methods.UpdateStudentMarkSqlRawAsync(context, 1, 888);
            Assert.True(results == 1);
        }

        [Fact]
        public void WhenUpdateStudentMarkSqlInterpolated_ThenSuccess()
        {
            var results = Methods.UpdateStudentMarkSqlInterpolated(context, 1, 999);
            Assert.True(results == 1);
        }
        [Fact]
        public async void WhenUpdateStudentMarkSqlInterpolatedAsync_ThenSuccess()
        {
            var results = await Methods.UpdateStudentMarkSqlInterpolatedAsync(context, 1, 999);
            Assert.True(results == 1);
        }
    }
}