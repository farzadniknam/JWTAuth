
namespace JWTAuth.Data.Repositories
{
    public interface IRepo<T> where T : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetAsync<TEntity, TTranslate>(int Id, bool doTranslate = true) where TEntity : class where TTranslate : class;
    }
}