using System.Data.SqlClient;
using Dapper;
using UnitOfWork.Entities;

namespace UnitOfWork.DataAccess.Dapper;

public class DapperContext : IStore
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

    public IQueryable<TEntity> GetEntitySet<TEntity>() where TEntity : Entity
    {
        return _sqlConnection.Query<TEntity>($"SELECT * FROM {GetPluralName<TEntity>()}").AsQueryable();
    }

    public void Add<TEntity>(TEntity order) where TEntity : Entity
    {
        _sqlConnection.Execute($"INSERT INTO {GetPluralName<TEntity>()} (Id) VALUES (@Id)", order.Id);
    }

    private static string GetPluralName<TEntity>() where TEntity : Entity
    {
        return typeof(TEntity).Name + "s";
    }
}