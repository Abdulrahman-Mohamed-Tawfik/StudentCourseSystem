using StudentCourseSystem.Core.Interfaces;
using StudentCourseSystem.Core.Models;
using StudentCourseSystem.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Data.Repositories
{
    public class CourseRepository : CommonRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<Course>> FilterCoursesAsync(string? filter = null, bool? isDeleted = false)
        {
            return (await GetAsync()).Where(a => filter == null || a.Name.ToLower().Contains(filter.ToLower()))
                                         .Where(a => a.IsDeleted == isDeleted);
        }
        public override IQueryable<Course> OrderBy(IQueryable<Course> entities, string? orderBy, bool isAccending = true)
        {
            if (orderBy != null)
            {
                switch (orderBy?.ToLower())
                {
                    case "name":
                        entities = isAccending ? entities.OrderBy(a => a.Name) : entities.OrderByDescending(a => a.Name);
                        break;
                }
            }
            return entities;
        }
    }

}
