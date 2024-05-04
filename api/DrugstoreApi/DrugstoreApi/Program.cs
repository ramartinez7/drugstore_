using DrugstoreApi.Models;
using DrugstoreApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DrugstoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            _ = builder.Services.AddScoped<IFarmacia, FarmaciaManager>();
            _ = builder.Services.AddControllers();
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen();

            _ = builder.Services.AddDbContext<FarmaciaContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Farmacia")));

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthorization();


            _ = app.MapControllers();

            app.Run();
        }
    }
}
