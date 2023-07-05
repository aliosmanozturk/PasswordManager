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
using PasswordManager.Database;

namespace PasswordManager.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFirebaseDal<Passwords> _firebaseDal; 
        private IFirebaseDal<Category> _categoryDal; 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _firebaseDal = new FirebaseDal<Passwords>();
            _categoryDal = new FirebaseDal<Category>();
        }

        public async Task<IActionResult> Index()
        {
            var list = await _firebaseDal.GetList();
            return View("Index", list.Data);
        }
        public IActionResult Create()
        {
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
        public async Task<IActionResult> Create(Passwords model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _firebaseDal.Add(model);
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Passwords model)
        {
            await _firebaseDal.Update(model);
            return await Index();
        }
    }
}