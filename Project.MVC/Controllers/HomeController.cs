using Microsoft.AspNetCore.Mvc;
using Project.BL.Services;
using Project.DAL.Models;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly CartService _service;

		public HomeController(CartService service)
		{
			_service = service;
		}

		public IActionResult Index()
        {
            List<Cart> carts = _service.GetAllCarts();
            return View(carts);
        }
    }
}
