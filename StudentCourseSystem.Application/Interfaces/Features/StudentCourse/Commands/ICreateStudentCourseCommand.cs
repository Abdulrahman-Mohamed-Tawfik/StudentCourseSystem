using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Commands
{
    public interface ICreateStudentCourseCommand
    {
        Task<StudentCourseEntity> ExecuteAsync(StudentCourseEntity studentCourseCreateDto);
    }
}
