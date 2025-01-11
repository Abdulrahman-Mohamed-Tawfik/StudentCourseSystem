using StudentCourseSystem.Application.Interfaces.Features.Course.Queries;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories.Features.Course.Queries
{
    public class GetAllCoursesQuery : IGetAllCoursesQuery
    {
        private readonly IQueryRepository<CourseEntity> _queryRepository;

        public GetAllCoursesQuery(IQueryRepository<CourseEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<CourseEntity>> ExecuteAsync()
        {
            return await _queryRepository.GetAllAsync();
        }
    }
}
