
using DrugstoreApi.Controllers;
using DrugstoreApi.Dto.Request;
using DrugstoreApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DrugstoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IFarmacia, FarmaciaManager>();   
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FarmaciaContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Farmacia")));

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
    }
}
