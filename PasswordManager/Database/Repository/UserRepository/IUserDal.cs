using PasswordManager.Database.EntityFramework;
using PasswordManager.Database.Firebase;
using PasswordManager.Models;

namespace PasswordManager.Database.Repository.UserRepository
{
    public interface IUserDal : IFirebaseDal<User>
    {
    }
}
