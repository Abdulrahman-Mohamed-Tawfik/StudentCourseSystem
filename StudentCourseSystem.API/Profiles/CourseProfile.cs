﻿using AutoMapper;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Courses;

namespace StudentCourseSystem.API.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
