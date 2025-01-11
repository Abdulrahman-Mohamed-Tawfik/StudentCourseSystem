using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Domain.Models;

namespace StudentCourseSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext _context;
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>()
                .HasKey(sc => sc.Id);

            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }


    }
}
