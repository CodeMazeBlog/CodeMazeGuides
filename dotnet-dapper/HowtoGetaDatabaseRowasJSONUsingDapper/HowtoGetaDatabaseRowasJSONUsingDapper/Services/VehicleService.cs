using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.Entities;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
           _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _vehicleRepository.GetVehicle(id);
        }
    }
}
