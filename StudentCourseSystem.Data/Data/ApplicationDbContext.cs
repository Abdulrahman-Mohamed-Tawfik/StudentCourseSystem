using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Core.Models;

namespace StudentCourseSystem.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext _context;
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}
