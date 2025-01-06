using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int CreditHours { get; set; }
        public bool isDeleted { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
