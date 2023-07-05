using PasswordManager.Database.EntityFramework;
using PasswordManager.Database.Firebase;
using PasswordManager.Database.Repository.PasswordsRepository;
using PasswordManager.Models;

namespace PasswordManager.Database.Repository.CategoryRepository
{
    public class EfCategoryDal : FirebaseDal<Category>,ICategoryDal
    {
    }
}
