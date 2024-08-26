using Microsoft.EntityFrameworkCore;
using PruebaSistran.Servicios.Services;
using SISTRAN.CAD.Models;

namespace PruebaSistran
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //mapeo de endpoints
            builder.Services.AddEndpointsApiExplorer();

            //scopes
            builder.Services.AddScoped<IPeopleRegister, PeopleRegisterService>();

            // conection string
            builder.Services.AddDbContext<PruebaSistranContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConectionString"));
            });
            //anadiendo controllers
            builder.Services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
