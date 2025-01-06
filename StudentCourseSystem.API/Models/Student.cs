using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required]
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool isDeleted { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
