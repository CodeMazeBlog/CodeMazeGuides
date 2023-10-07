namespace HowtoGetaDatabaseRowasJSONUsingDapper.Contracts
{
    public interface IRepository
    {
        public Task<dynamic> GetById(int id);
    }
}
