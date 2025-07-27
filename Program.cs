
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagementSys_SURE.Models;
using StudentManagementSys_SURE.Repository;
using StudentManagementSys_SURE.UnitOfWork;

namespace StudentManagementSys_SURE
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
            builder.Services.AddDbContext<StudentManagContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("Appcontext")));
            //builder.Services.AddScoped<StudentRepository>();
            //builder.Services.AddScoped<GenericRepository<Student>>();
            //builder.Services.AddScoped<GenericRepository<Department>>();
            builder.Services.AddScoped<UnitWork>();
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
