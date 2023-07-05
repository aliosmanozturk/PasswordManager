using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database;
using PasswordManager.Models;

namespace PasswordManager.Controllers
{
    public class CategoryController : Controller
    {
        private IFirebaseDal<Category> _firebaseDal = new FirebaseDal<Category>();
        public async Task<IActionResult> Index()
        {
            var list = await _firebaseDal.GetList();
            return View("Index", list.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(string id)
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
        public async Task<IActionResult> Create(Category model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _firebaseDal.Add(model);
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            await _firebaseDal.Update(model);
            return await Index();
        }
    }
}
