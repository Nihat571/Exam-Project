using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
	public class CartDBContext:IdentityDbContext<AppUser>
	{
        public CartDBContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Cart> Carts { get; set; }
    }
}
