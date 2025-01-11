using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Student.Queries
{
    public interface IFilterStudentQuery
    {
        Task<IQueryable<StudentEntity>> ExecuteAsync(string? filter = null, bool? isDeleted = false);
    }
}
