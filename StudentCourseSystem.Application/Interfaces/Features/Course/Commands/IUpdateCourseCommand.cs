using StudentCourseSystem.DTOs.Courses;
using StudentCourseSystem.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Course.Commands
{
    public interface IUpdateCourseCommand
    {
        Task ExecuteAsync(int id, CourseUpdateDto courseDto);
    }
}
