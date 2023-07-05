using System.Linq.Expressions;

namespace PasswordManager.Database.EntityFramework
{
    public interface IEntityRepository<T>
    {
        Task<T> Add(T entity);
        Task<List<T>> AddRange(List<T> entities);
        Task Update(T entity);
        Task UpdateRange(List<T> entities);
        Task Delete(T entity);
        Task DeleteRange(List<T> entities);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> GetFirst();
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
