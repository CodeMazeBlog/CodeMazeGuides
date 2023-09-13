using Dapper;
using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.DbContext;
using HowtoGetaDatabaseRowasJSONUsingDapper.Entities;
using Newtonsoft.Json;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DapperContext _context;

        public VehicleRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var query = "SELECT * FROM Vehicles WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            var vehicle = await connection.QuerySingleOrDefaultAsync<Vehicle>(query, new { id });
            if (vehicle != null)
            {
                var json = JsonConvert.SerializeObject(vehicle, Formatting.Indented);
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
            return vehicle;
        }
    }
}