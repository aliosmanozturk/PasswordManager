using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using System.Diagnostics;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Newtonsoft.Json;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PasswordManager.Database.Firebase;
using PasswordManager.Database.Repository.CategoryRepository;
using PasswordManager.Database.Repository.PasswordsRepository;

namespace PasswordManager.Controllers
{

    public class HomeController : Controller
    {
        private IPasswordsDal _passwordsDal;
        private ICategoryDal _categoryDal;

        public HomeController()
        {
            _passwordsDal = new EfPasswordsDal();
            _categoryDal = new EfCategoryDal();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _passwordsDal.GetList();
            return View("Index", list.Data);
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryDal.GetList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var category in categories.Data)
            {
                SelectListItem item = new SelectListItem();
                item.Text = category.Name;
                item.Value = category.Id;
                selectList.Add(item);
            }
            ViewBag.SelectList = selectList;
            PasswordGenerator.PasswordGenerator pwdGen1 = new PasswordGenerator.PasswordGenerator();
            ViewBag.password = pwdGen1.Next();
            return View();
        }

      
        public async Task<IActionResult> Edit(string id)
        {
            var categories = await _categoryDal.GetList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var category in categories.Data)
            {
                SelectListItem item = new SelectListItem();
                item.Text=category.Name;
                item.Value = category.Id;
                selectList.Add(item);
            }
            ViewBag.SelectList = selectList;
            PasswordGenerator.PasswordGenerator pwdGen1 = new PasswordGenerator.PasswordGenerator();
            ViewBag.password = pwdGen1.Next();
            var user = await _passwordsDal.GetById(id);
            return View(user.Data);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _passwordsDal.GetById(id);
            await _passwordsDal.Delete(user.Data);
            return await Index();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Passwords model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _passwordsDal.Add(model);
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Passwords model)
        {
            await _passwordsDal.Update(model);
            return await Index();
        }
    }
}