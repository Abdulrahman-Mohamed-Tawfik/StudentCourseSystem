
using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Repositories;
using StudentCourseSystem.Infrastructure.Data;

namespace StudentCourseSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // connect to db
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

            // Inject Student Repo
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            // Inject Course Repo
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();

            // Register AutoMappers
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
