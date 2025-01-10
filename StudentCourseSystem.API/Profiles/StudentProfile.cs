using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Students;

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
