using Project.DAL.Contexts;
using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services
{
	public class CartService
	{
		private readonly CartDBContext _cartDB;

		public CartService(CartDBContext cartDB)
		{
			_cartDB = cartDB;
		}


		#region READ

		public List<Cart> GetAllCarts()
		{
			return _cartDB.Carts.ToList();
		}

		public Cart GetCartById(int id)
		{
			Cart? clickedCArt = _cartDB.Carts.Find(id);
			if (clickedCArt is not null)
			{
				return clickedCArt;
			}
			else
			{
				throw new Exception("not found");
			}
		}



		#endregion

		#region CREATE

		public void AddCart(Cart cart)
		{
			_cartDB.Carts.Add(cart);
			_cartDB.SaveChanges();

		}

		#endregion


		#region UPDATE

		public void UpdateCart(int id,Cart updatedCart)
		{
			Cart clickedCart = GetCartById(id);
			if (clickedCart is not null)
			{
				clickedCart.Name = updatedCart.Name;
				clickedCart.Specialty = updatedCart.Specialty;
				clickedCart.ImgUrl = updatedCart.ImgUrl;
				_cartDB.SaveChanges();
			}

			else
			{
				throw new Exception("data not found");
			}
		}


		#endregion

		#region DELETE

		public void DeleteCart(int id) 
		{
			Cart cart = GetCartById(id);
			_cartDB.Carts.Remove(cart);
			_cartDB.SaveChanges();
		}

		#endregion
	}
}
