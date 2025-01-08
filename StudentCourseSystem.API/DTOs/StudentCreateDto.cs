﻿using System.ComponentModel.DataAnnotations;

namespace StudentCourseSystem.API.DTOs
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }

    }
}
