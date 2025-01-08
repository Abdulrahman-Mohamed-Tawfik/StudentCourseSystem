using StudentCourseSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Core.Interfaces
{
    public interface ICourseRepository:ICommonRepository<Course>
    {
        public Task<IQueryable<Course>> FilterCoursesAsync(string? filter = null, bool? isDeleted = false);
    }
}
