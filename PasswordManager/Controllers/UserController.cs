using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database;
using PasswordManager.Models;

namespace PasswordGenerator.Controllers
{
    public class UserController : Controller
    {
        private IFirebaseDal<User> _firebaseDal = new FirebaseDal<User>();
        public async  Task<IActionResult> GetList()
        {
            var list = await _firebaseDal.GetList();
            return View(list.Data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid().ToString();
                await _firebaseDal.Add(model);
                return View("GetList");
            }
            else
            {
                return View(model);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            await _firebaseDal.Update(model);
            return View("GetList");
        }
        [HttpPost]
        public IActionResult Delete(LoginModel model)
        {
            return View("GetList");
        }
        
    }
}
