using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.DTOs.Students
{
    public class StudentUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public char Gender { get; set; }

        //public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
