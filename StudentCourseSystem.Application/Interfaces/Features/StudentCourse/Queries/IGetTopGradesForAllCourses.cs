using StudentCourseSystem.DTOs.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Queries
{
    public interface IGetTopGradesForAllCourses
    {
        Task<IEnumerable<TopGradeDto>> ExecuteAsync();
    }
}
