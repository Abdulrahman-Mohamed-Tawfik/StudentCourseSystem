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
    public class GetAllStudentsQuery : IGetAllStudentsQuery
    {
        private readonly IQueryRepository<StudentEntity> _repository;

        public GetAllStudentsQuery(IQueryRepository<StudentEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StudentEntity>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }

}
