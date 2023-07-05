using PasswordManager.Database.EntityFramework;
using PasswordManager.Database.Firebase;
using PasswordManager.Models;

namespace PasswordManager.Database.Repository.PasswordsRepository
{
    public interface IPasswordsDal: IFirebaseDal<Passwords>
    {
    }
}
