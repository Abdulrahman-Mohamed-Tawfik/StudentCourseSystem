using Microsoft.EntityFrameworkCore;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Queries;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories.Features.StudentCourse.Queries
{
    public class GetTopTotalGrades : IGetTopTotalGrades
    {
        private readonly IQueryRepository<StudentCourseEntity> _queryRepository;

        public GetTopTotalGrades(IQueryRepository<StudentCourseEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<TotalGradeDto>> ExecuteAsync()
        {
            return await _queryRepository.GetAllQueryableInclude(null, sc => sc.Student, sc => sc.Course)
            .GroupBy(sc => new { sc.StudentId, sc.Student.Name })
            .Select(group => new TotalGradeDto
            {
                StudentId = group.Key.StudentId,
                StudentName = group.Key.Name,
                TotalGrade = group.Sum(sc => sc.StudentGrade)
            })
            .OrderByDescending(dto => dto.TotalGrade)
            .Take(3)
            .ToListAsync();
        }
    }
}
