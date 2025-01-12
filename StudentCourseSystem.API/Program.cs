
using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Interfaces.Features.Course.Commands;
using StudentCourseSystem.Application.Interfaces.Features.Course.Queries;
using StudentCourseSystem.Application.Interfaces.Features.Student.Commands;
using StudentCourseSystem.Application.Interfaces.Features.Student.Queries;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Commands;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Queries;
using StudentCourseSystem.Application.Repositories;
using StudentCourseSystem.Application.Repositories.Features.Course.Commands;
using StudentCourseSystem.Application.Repositories.Features.Course.Queries;
using StudentCourseSystem.Application.Repositories.Features.Student.Commands;
using StudentCourseSystem.Application.Repositories.Features.Student.Queries;
using StudentCourseSystem.Application.Repositories.Features.StudentCourse.Commands;
using StudentCourseSystem.Application.Repositories.Features.StudentCourse.Queries;
using StudentCourseSystem.Domain.Models;
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

            //Inject Main Services
            //Student
            builder.Services.AddScoped<ICommandRepository<StudentEntity>, CommandRepository<StudentEntity>>();
            builder.Services.AddScoped<IQueryRepository<StudentEntity>, QueryRepository<StudentEntity>>();
            //Course
            builder.Services.AddScoped<IQueryRepository<CourseEntity>, QueryRepository<CourseEntity>>();
            builder.Services.AddScoped<ICommandRepository<CourseEntity>, CommandRepository<CourseEntity>>();
            //StudentCourse
            builder.Services.AddScoped<IQueryRepository<StudentCourseEntity>, QueryRepository<StudentCourseEntity>>();
            builder.Services.AddScoped<ICommandRepository<StudentCourseEntity>, CommandRepository<StudentCourseEntity>>();


            //Inject Command Services
            //Student
            builder.Services.AddScoped<ICreateStudentCommand, CreateStudentCommand>();
            builder.Services.AddScoped<IUpdateStudentCommand, UpdateStudentCommand>();
            builder.Services.AddScoped<IDeleteStudentCommand, DeleteStudentCommand>();
            //Course
            builder.Services.AddScoped<ICreateCourseCommand, CreateCourseCommand>();
            builder.Services.AddScoped<IUpdateCourseCommand, UpdateCourseCommand>();
            builder.Services.AddScoped<IDeleteCourseCommand, DeleteCourseCommand>();
            //StudentCourse
            builder.Services.AddScoped<ICreateStudentCourseCommand, CreateStudentCourseCommand>();

            //Inject Query Services
            //Student
            builder.Services.AddScoped<IGetAllStudentsQuery, GetAllStudentsQuery>();
            builder.Services.AddScoped<IGetStudentByIdQuery, GetStudentByIdQuery>();
            builder.Services.AddScoped<IGetStudentQuery, GetStudentQuery>();
            builder.Services.AddScoped<IFilterStudentQuery, FilterStudentQuery>();
            //Course
            builder.Services.AddScoped<IGetAllCoursesQuery, GetAllCoursesQuery>();
            builder.Services.AddScoped<IGetCourseByIdQuery, GetCourseByIdQuery>();
            //StudentCourse
            builder.Services.AddScoped<IGetTopGradesForAllCourses, GetTopGradesForAllCourses>();
            builder.Services.AddScoped<IGetTopGradesForCourseQuery, GetTopGradesForCourseQuery>();
            builder.Services.AddScoped<IGetTopTotalGrades, GetTopTotalGrades>();





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
