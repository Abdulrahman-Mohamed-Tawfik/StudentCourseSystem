using AutoMapper;
using StudentCourseSystem.API.DTOs;
using StudentCourseSystem.Core.Models;

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
