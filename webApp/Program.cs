using Microsoft.EntityFrameworkCore;
using webApp.AppContext;
using webApp.Services;
using webApp.Services.Interfaces;

namespace webApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IProductService, ProductService>();
        string connection = builder.Configuration.GetConnectionString("FSNConnection");

        builder.Services.AddDbContext<ApplicationDbContext>(op =>
        {
            op.UseSqlServer(connection);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Product}/{action=Index}/{id?}");

        app.Run();
    }
}