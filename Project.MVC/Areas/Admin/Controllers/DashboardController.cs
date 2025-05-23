using Microsoft.AspNetCore.Mvc;
using Project.BL.Services;
using Project.BL.ViewModels;
using Project.DAL.Models;

namespace Project.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		private readonly CartService _service;

		public DashboardController(CartService service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			List<Cart> carts = _service.GetAllCarts();
			return View(carts);
		}


		#region Create

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]


		public IActionResult Create(CreateCartVM newVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			if (newVM.File is not null)
			{
				string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);
				string extension = Path.GetExtension(newVM.File.FileName);
				string resultname = filename + Guid.NewGuid().ToString() + extension;

				string uploadedImgPath = @"C:\Users\II Novbe\source\repos\Event-Project\Project.MVC\wwwroot\assets\uploadedImages";
				if (!Directory.Exists(uploadedImgPath))
				{
					Directory.CreateDirectory(uploadedImgPath);
				}

				uploadedImgPath = Path.Combine(uploadedImgPath,resultname);
				FileStream stream = new FileStream(uploadedImgPath,FileMode.Create);
				newVM.File.CopyTo(stream);
				Cart newCart = new Cart
				{
					Name = newVM.Name,
					Specialty = newVM.Specialty,
					ImgUrl = resultname,
				};
				_service.AddCart(newCart);
			}
			else
			{
                Cart newCart = new Cart
                {
                    Name = newVM.Name,
                    Specialty = newVM.Specialty,
                    ImgUrl = "default-image.jpg",
                };
                _service.AddCart(newCart);
            }



            return RedirectToAction(nameof(Index));
		}

		#endregion


		#region UPDATE
		
		public IActionResult Update(int id)
		{
			Cart clickedCart = _service.GetCartById(id);
            UpdateCartVM updatedCart = new UpdateCartVM
			{
				Name = clickedCart.Name,
				Specialty = clickedCart.Specialty,
			};
				
			return View(updatedCart);
		}


		[HttpPost]
		public IActionResult Update(int id,UpdateCartVM updatedVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

            if (updatedVM.File is not null)
            {
                string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
                string extension = Path.GetExtension(updatedVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extension;

                string uploadedImgPath = @"C:\Users\II Novbe\source\repos\Event-Project\Project.MVC\wwwroot\assets\uploadedImages";
                if (!Directory.Exists(uploadedImgPath))
                {
                    Directory.CreateDirectory(uploadedImgPath);
                }

                uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
                FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);
                updatedVM.File.CopyTo(stream);
                Cart updatedCart = new Cart
                {
                    Name = updatedVM.Name,
                    Specialty = updatedVM.Specialty,
                    ImgUrl = resultname,
                };
                _service.UpdateCart(id, updatedCart);
            }
            else
            {
				Cart clickedCart = _service.GetCartById(id);
                Cart updatedCart = new Cart
                {
                    Name = updatedVM.Name,
                    Specialty = updatedVM.Specialty,
                    ImgUrl = clickedCart.ImgUrl,
                };
                _service.UpdateCart(id,updatedCart);
            }
            return RedirectToAction(nameof(Index));
		}

		#endregion

		#region DELETE

		public IActionResult Delete(int id)
		{
			_service.DeleteCart(id);
			return RedirectToAction(nameof(Index));
		}

		#endregion
	}
}
