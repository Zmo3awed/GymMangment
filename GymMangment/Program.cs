using GymMangment.Contexts;
using GymMangment.Repository.Classes;
using GymMangment.Repository.Interfaces;
using GymMangment.Repository.IRepositry;
using Microsoft.EntityFrameworkCore;

namespace GymMangment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymContext>(
             op => op.UseSqlServer(
                 builder.Configuration.GetConnectionString("DeafultConnection")
                 ));


            builder.Services.AddScoped<IPlanRepositry, PlanRepositry>();
            builder.Services.AddScoped<IMembershipRepositry, MembershipRipositry>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
