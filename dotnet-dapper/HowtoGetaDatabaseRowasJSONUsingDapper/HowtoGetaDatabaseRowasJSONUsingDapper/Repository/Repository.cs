using Dapper;
using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.DbContext;
using HowtoGetaDatabaseRowasJSONUsingDapper.Helper;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Repository
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;
        private readonly DapperContext _context;

        public Repository(ILogger<Repository> logger, DapperContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<dynamic> GetById(int id)
        {
            var query = "SELECT * FROM Entities WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var entity = await connection.QuerySingleOrDefaultAsync(query, new { id });
                if (entity != null)
                {
                    var json = JsonHelper.ConvertToJson(entity);
                    _logger.LogInformation($"{json}");
                }
                else
                {
                    _logger.LogInformation("Entity not found!");
                }
                return entity;
            }
        }
    }
}