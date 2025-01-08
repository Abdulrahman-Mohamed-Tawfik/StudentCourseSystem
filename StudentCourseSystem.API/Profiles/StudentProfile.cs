using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentCourseSystem.API.DTOs;
using StudentCourseSystem.Core.Models;
using AutoMapper;

namespace StudentCourseSystem.API.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
        }
    }
}
