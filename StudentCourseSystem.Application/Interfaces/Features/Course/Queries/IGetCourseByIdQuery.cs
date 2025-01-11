using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Course.Queries
{
    public interface IGetCourseByIdQuery
    {
        Task<CourseEntity?> ExecuteAsync(int id);
    }
}
