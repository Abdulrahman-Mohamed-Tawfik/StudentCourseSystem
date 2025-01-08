using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.API.DTOs
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
    }
}
