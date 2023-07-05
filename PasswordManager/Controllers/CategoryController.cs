using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database.Firebase;
using PasswordManager.Database.Repository.CategoryRepository;
using PasswordManager.Models;

namespace PasswordManager.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryDal _categoryDal;


        public CategoryController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _categoryDal.GetList();
            return View("Index", list.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _categoryDal.GetById(id);
            return View(user.Data);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _categoryDal.GetById(id);
            await _categoryDal.Delete(user.Data);
            return await Index();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _categoryDal.Add(model);
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            await _categoryDal.Update(model);
            return await Index();
        }
    }
}
