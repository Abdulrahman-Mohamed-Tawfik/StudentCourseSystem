using StudentCourseSystem.Application.Interfaces.Features.Student.Queries;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;

namespace StudentCourseSystem.Application.Repositories.Features.Student.Queries
{
    public class GetStudentByIdQuery : IGetStudentByIdQuery
    {
        private readonly IQueryRepository<StudentEntity> _queryRepository;

        public GetStudentByIdQuery(IQueryRepository<StudentEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<StudentEntity?> ExecuteAsync(int id)
        {
            var query = await _queryRepository.GetAsync(s => s.Id == id);
            return query.FirstOrDefault();
        }
    }
}
