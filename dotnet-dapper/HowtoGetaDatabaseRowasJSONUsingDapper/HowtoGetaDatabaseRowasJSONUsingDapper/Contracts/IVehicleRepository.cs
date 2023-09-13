using HowtoGetaDatabaseRowasJSONUsingDapper.Entities;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Contracts
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> GetVehicle(int id);
    }
}
