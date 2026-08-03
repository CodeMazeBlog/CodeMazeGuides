namespace Writer.Api.Repositories.Interfaces
{
    public interface IWriterRepository
    {
        List<Models.Writer> GetAll();
        Models.Writer? Get(int id);
        Models.Writer Insert(Models.Writer writer);
    }
}
