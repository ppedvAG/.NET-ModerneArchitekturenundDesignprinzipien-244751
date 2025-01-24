using Microsoft.EntityFrameworkCore;
using ppedv.RentABrain.Logic.Services;
using ppedv.RentABrain.Model;
using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;

namespace ppedv.RentABrain.UI.WebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            RegisterServices(builder);

            Startup(builder);
        }

        private static void RegisterServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Fail Fast: Wenn connection string in appsettings.json fehlt fliegt beim Start der Applikation gleich ein Fehler
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            // Wir wollen lose Kopplung weswegen wir unsere Controller gegen die Repositories implementieren statt direkt gegen den DbContext
            //builder.Services.AddDbContext<RentABrainContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IRepository<Brain>>(p => new RentABrainRepositoryAdapter<Brain>(connectionString));
            builder.Services.AddTransient<IRepository<Customer>>(p => new RentABrainRepositoryAdapter<Customer>(connectionString));
            builder.Services.AddTransient<IRepository<Product>>(p => new RentABrainRepositoryAdapter<Product>(connectionString));
            builder.Services.AddTransient<IRepository<Order>>(p => new RentABrainRepositoryAdapter<Order>(connectionString));

            builder.Services.AddScoped<IProductService, ProductService>();
        }

        private static void Startup(WebApplicationBuilder builder)
        {
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
