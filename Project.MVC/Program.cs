using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BL.Services;
using Project.DAL.Contexts;
using Project.DAL.Models;

namespace Project.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CartDBContext>(opt=>opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<CartService>();

            //for identity
            //builder.Services.AddIdentity<AppUser, AppRole>()
            //    .AddEntityFrameworkStores<CartDBContext>()
            //    .AddDefaultTokenProviders();
            

            var app = builder.Build();

            app.UseStaticFiles();
            //for identity
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );


			app.MapControllerRoute(
                name:"default",
                pattern:"{controller=Home}/{action=Index}"
                );
            

            app.Run();
        }
    }
}
