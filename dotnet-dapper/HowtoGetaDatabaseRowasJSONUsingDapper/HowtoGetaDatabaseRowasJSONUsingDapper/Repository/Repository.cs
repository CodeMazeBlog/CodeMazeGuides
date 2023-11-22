using Dapper;
using Newtonsoft.Json;
using RetrievingDbRowAsJsonWithDapper.Contracts;
using RetrievingDbRowAsJsonWithDapper.DbContext;

namespace RetrievingDbRowAsJsonWithDapper.Repository;

public class Repository : IRepository
{
    private readonly ILogger<Repository> _logger;
    private readonly DapperContext _context;

    public Repository(ILogger<Repository> logger, DapperContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<dynamic?> GetById(int id)
    {
        const string query = "SELECT * FROM Entities WHERE Id = @Id";

        using (var connection = _context.CreateConnection())
        {
            var entity = await connection.QuerySingleOrDefaultAsync(query, new { id });
            if (entity != null)
            {
                string json = JsonConvert.SerializeObject(entity, Formatting.Indented);
                _logger.LogInformation("Object as JSON {json}", json);
            }
            else
            {
                _logger.LogInformation("Entity not found!");
            }

            return entity;
        }
    }
}