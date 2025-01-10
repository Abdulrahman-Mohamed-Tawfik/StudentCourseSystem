﻿using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.DTOs.Courses
{
    public class CourseUpdateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? CreditHours { get; set; }
    }
}
