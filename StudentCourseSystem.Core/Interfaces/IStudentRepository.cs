using StudentCourseSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Core.Interfaces
{
    public interface IStudentRepository : ICommonRepository<Student>
    {
        public Task<IQueryable<Student>> FilterStudentsAsync(string? filter = null, bool? isDeleted = false);

    }
}
