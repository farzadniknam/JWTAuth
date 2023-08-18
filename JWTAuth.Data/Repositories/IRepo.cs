
namespace JWTAuth.Data.Repositories
{
    public interface IRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int Id);
    }
}