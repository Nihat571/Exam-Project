using Microsoft.EntityFrameworkCore;
using Project.BL.Services;
using Project.DAL.Contexts;

namespace Project.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string _connectionStr = @"Server=DESKTOP-GTVND9D;Database=SpeakersDB;Trusted_Connection=True;TrustServerCertificate=True";
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CartDBContext>(opt=>opt.UseSqlServer(_connectionStr));
            builder.Services.AddScoped<CartService>();

            var app = builder.Build();

            app.UseStaticFiles();

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
