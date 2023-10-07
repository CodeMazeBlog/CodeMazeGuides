namespace HowtoGetaDatabaseRowasJSONUsingDapper.Contracts
{
    public interface IService
    {
        public Task<dynamic> GetById(int id);
    }
}
