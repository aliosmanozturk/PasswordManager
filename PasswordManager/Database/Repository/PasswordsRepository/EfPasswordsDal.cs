using PasswordManager.Database.EntityFramework;
using PasswordManager.Database.Firebase;
using PasswordManager.Database.Repository.UserRepository;
using PasswordManager.Models;

namespace PasswordManager.Database.Repository.PasswordsRepository
{
    public class EfPasswordsDal: FirebaseDal<Passwords>,IPasswordsDal
    {
    }
}
