using StudentCourseSystem.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Course.Commands
{
    public interface ICreateCourseCommand
    {
        Task ExecuteAsync(CourseCreateDto courseDto);
    }
}
