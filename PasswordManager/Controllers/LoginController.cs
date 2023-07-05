using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using PasswordManager.Database.Firebase;

namespace PasswordManager.Controllers
{
    public class LoginController : Controller
    {
        private IFirebaseDal<User> _firebaseDal = new FirebaseDal<User>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _firebaseDal.GetByEmail(model.Email);
                if (user.Data == null || user.Data.Password != model.Password)
                {
                    ViewBag.error = "Kullanıcı Adı veya Şifreniz Hatalı";
                    return View("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Index", model);
            }
           
            
            
        }
    }
}
