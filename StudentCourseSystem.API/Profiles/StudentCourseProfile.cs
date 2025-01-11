using AutoMapper;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.StudentCourse;

namespace StudentCourseSystem.API.Profiles
{
    public class StudentCourseProfile:Profile
    {
        public StudentCourseProfile()
        {
            CreateMap<StudentCourseCreateDto, StudentCourseEntity>()
                .ForMember(dest => dest.Student, opt => opt.Ignore()) // Ignore navigation properties
                .ForMember(dest => dest.Course, opt => opt.Ignore())  // Ignore navigation properties
                .ForMember(dest => dest.StudentGrade, opt => opt.MapFrom(src => src.StudentGrade ?? 0)); // Default to 0 if StudentGrade is null
        }
    }
}
