using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Student.Queries
{
    public interface IGetStudentByIdQuery
    {
        Task<StudentEntity?> ExecuteAsync(int id);
    }
}
