using PasswordManager.Database.EntityFramework;
using PasswordManager.Database.Firebase;
using PasswordManager.Models;

namespace PasswordManager.Database.Repository.CategoryRepository
{
    public interface ICategoryDal: IFirebaseDal<Category>
    {
    }
}
