namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels.Contracts
{
    public interface IDataRepository
    {
        public interface IDataRepository<TEntity, TDto>
        {
            IEnumerable<TDto> GetAll();
            TDto? GetDto(int id);
            TEntity? Get(int id);
            void Add(TDto entity);
            void Update(TEntity entityToUpdate, TDto entity);
            void Delete(TEntity entity);
        }
    }
}