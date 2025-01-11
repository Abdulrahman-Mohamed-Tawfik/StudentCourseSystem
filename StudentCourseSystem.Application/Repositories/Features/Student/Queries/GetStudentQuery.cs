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
    public class GetStudentQuery : IGetStudentQuery
    {
        private readonly IQueryRepository<StudentEntity> _queryRepository;

        public GetStudentQuery(IQueryRepository<StudentEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IQueryable<StudentEntity>> ExecuteAsync()
        {
            return await _queryRepository.GetAllAsync();
        }
    }
}
