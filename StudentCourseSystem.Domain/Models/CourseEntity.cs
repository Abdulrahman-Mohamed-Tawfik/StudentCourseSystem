using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.Domain.Models
{
    public class CourseEntity
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public int CreditHours { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<StudentCourseEntity> StudentCourses { get; set; }

    }
}
