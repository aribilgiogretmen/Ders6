using Microsoft.AspNetCore.Mvc;

namespace Ders6.Controllers
{
    public class LoginController : Controller
    {
        private const string Username = "admin";
        private const string Password = "12345a";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username,string password)
        {
            if (username == Username && password == Password)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");

            }

            ViewBag.message = "Hatalı kullanıcı adı ve şifre";


            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Login");
        }
   }
}
