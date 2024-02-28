
using Microsoft.EntityFrameworkCore;
using System;
using ETour.DbRepos;
using ETour.Repository;


namespace ETour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            builder.Services.AddTransient<ICustomerRepository, SQLCustomer>();          
            builder.Services.AddTransient<IBookingRepository, BookingRepository>();
            builder.Services.AddTransient<IPackageRepository, PackageRepository>();
            builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
            builder.Services.AddTransient<IIternaryService, SQLIternaryRepository>();
            builder.Services.AddTransient<ICostRepository, SQLCostRepository>();
            builder.Services.AddTransient<IDateRepository, DateRepository>();

            builder.Services.AddDbContext<ScottDbContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("ETourDBConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(
            (p) => p.AddDefaultPolicy(policy => policy.WithOrigins("*")
           .AllowAnyHeader()
           .AllowAnyMethod()

   ));
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
            app.UseCors();

            app.Run();
        }
    }
}
