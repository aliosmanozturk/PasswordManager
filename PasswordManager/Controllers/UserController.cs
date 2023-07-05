using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database.Firebase;
using PasswordManager.Models;

namespace PasswordGenerator.Controllers
{
    public class UserController : Controller
    {
        private IFirebaseDal<User> _firebaseDal = new FirebaseDal<User>();
        public async  Task<IActionResult> Index()
        {
            var list = await _firebaseDal.GetList();
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
            var user = await _firebaseDal.GetById(id);
            return View(user.Data);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _firebaseDal.GetById(id);
            await _firebaseDal.Delete(user.Data);
            return await Index();
        }
        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _firebaseDal.Add(model);
            return await Index();
        }
       
        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            await _firebaseDal.Update(model);
            return await Index();
        }
       
        
    }
}
