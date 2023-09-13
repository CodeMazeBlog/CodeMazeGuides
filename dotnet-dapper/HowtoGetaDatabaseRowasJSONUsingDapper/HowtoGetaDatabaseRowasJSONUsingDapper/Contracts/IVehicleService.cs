using HowtoGetaDatabaseRowasJSONUsingDapper.Entities;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Contracts
{
    public interface IVehicleService
    {
        public Task<Vehicle> GetVehicle(int id);
    }
}
