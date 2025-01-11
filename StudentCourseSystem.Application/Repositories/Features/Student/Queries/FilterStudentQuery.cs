using StudentCourseSystem.Application.Interfaces.Features.Student.Queries;
using StudentCourseSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseSystem.Domain.Models;

namespace StudentCourseSystem.Application.Repositories.Features.Student.Queries
{
    public class FilterStudentQuery : IFilterStudentQuery
    {
        private readonly IQueryRepository<StudentEntity> _queryRepository;

        public FilterStudentQuery(IQueryRepository<StudentEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IQueryable<StudentEntity>> ExecuteAsync(string? filter = null, bool? isDeleted = false)
        {
            var query = await _queryRepository.GetAsync(s =>
                (filter == null || s.Name.ToLower().Contains(filter.ToLower())) &&
                s.IsDeleted == isDeleted);

            return query;
        }
    }
}
