using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using System.Diagnostics;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Newtonsoft.Json;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;
using System.Security.Cryptography.Xml;
using PasswordManager.Database;

namespace PasswordManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IFirebaseDal<User> _userDal; 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userDal = new FirebaseDal<User>();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}