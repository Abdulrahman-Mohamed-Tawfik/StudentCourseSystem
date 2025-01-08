using StudentCourseSystem.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.API.DTOs
{
    public class CourseUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreditHours { get; set; }
    }
}
