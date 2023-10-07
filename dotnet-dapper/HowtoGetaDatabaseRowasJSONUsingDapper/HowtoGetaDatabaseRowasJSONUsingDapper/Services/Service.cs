using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
           _repository = repository;
        }

        public async Task<dynamic> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
