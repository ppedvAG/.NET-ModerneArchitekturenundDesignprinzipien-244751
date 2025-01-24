
using ppedv.RentABrain.Logic.Services;
using ppedv.RentABrain.Model.Contracts;
using ppedv.RentABrain.Model.Domain;
using ppedv.RentABrain.Model;
using Microsoft.EntityFrameworkCore;

namespace ppedv.RentABrain.UI.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            RegisterServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void RegisterServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Fail Fast: Wenn connection string in appsettings.json fehlt fliegt beim Start der Applikation gleich ein Fehler
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            // Wir wollen lose Kopplung weswegen wir unsere Controller gegen die Repositories implementieren statt direkt gegen den DbContext
            builder.Services.AddDbContext<RentABrainContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IRepository<Brain>>(p => new RentABrainRepositoryAdapter<Brain>(connectionString));
            builder.Services.AddTransient<IRepository<Customer>>(p => new RentABrainRepositoryAdapter<Customer>(connectionString));
            builder.Services.AddTransient<IRepository<Product>>(p => new RentABrainRepositoryAdapter<Product>(connectionString));
            builder.Services.AddTransient<IRepository<Order>>(p => new RentABrainRepositoryAdapter<Order>(connectionString));

            builder.Services.AddScoped<IProductService, ProductService>();
        }
    }
}
