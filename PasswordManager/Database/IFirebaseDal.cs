using Google.Cloud.Firestore;
using PasswordManager.Models;

namespace PasswordManager.Database
{
    public interface IFirebaseDal<T>
    {
        public Task<Result> Add(T entity);
        public Task<Result> Update(T entity);
        public Task<Result> Delete(T entity);
        public Task<DataResult<T>> GetById(string id);
        Task<DataResult<T>> GetByEmail(string email);
        public Task<DataResult<List<T>>> GetList();
    }
}
