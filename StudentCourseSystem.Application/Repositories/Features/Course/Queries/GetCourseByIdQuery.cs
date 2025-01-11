using StudentCourseSystem.Application.Interfaces.Features.Course.Queries;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StudentCourseSystem.Application.Repositories.Features.Course.Queries
{
    public class GetCourseByIdQuery : IGetCourseByIdQuery
    {
        private readonly IQueryRepository<CourseEntity> _queryRepository;

        public GetCourseByIdQuery(IQueryRepository<CourseEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<CourseEntity?> ExecuteAsync(int id)
        {
            var query = await _queryRepository.GetAsync(c => c.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
