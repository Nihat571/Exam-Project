using Microsoft.AspNetCore.Mvc;
using Project.DAL.Models;

namespace Project.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AppUser newUser)
        {



            return RedirectToAction(nameof(Index));
        }
    }
}
