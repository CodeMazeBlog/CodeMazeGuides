using System.Data.SqlClient;
using Dapper;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess.Dapper;

public class DapperContext : IDatabase
{
    private readonly SqlConnection _sqlConnection;

    public DapperContext(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public async Task<ITransaction> BeginTransactionAsync()
    {
        var sqlTransaction = await _sqlConnection.BeginTransactionAsync();
        
        return new DapperTransaction(sqlTransaction);
    }

    public IQueryable<Order> Orders => _sqlConnection.Query<Order>("SELECT * FROM Orders").AsQueryable();
    public void AddOrder(Order order)
    {
        _sqlConnection.Execute($"INSERT INTO Orders (Id) VALUES (@Id)", order.Id);
    }
}