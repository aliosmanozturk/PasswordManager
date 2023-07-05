using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database.Firebase;
using PasswordManager.Database.Repository.UserRepository;
using PasswordManager.Models;

namespace PasswordGenerator.Controllers
{
    public class UserController : Controller
    {
        private IUserDal _userDal;


        public UserController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async  Task<IActionResult> Index()
        {
            var list = await _userDal.GetList();
            return View("Index",list.Data);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Register()
        {
            
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userDal.GetById(id);
            return View(user.Data);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userDal.GetById(id);
            await _userDal.Delete(user.Data);
            return await Index();
        }
        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _userDal.Add(model);
            return await Index();
        }
       
        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            await _userDal.Update(model);
            return await Index();
        }
       
        
    }
}
