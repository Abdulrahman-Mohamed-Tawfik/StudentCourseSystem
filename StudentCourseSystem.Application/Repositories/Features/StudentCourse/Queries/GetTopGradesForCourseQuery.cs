using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Queries;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.DTOs.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseSystem.Application.Repositories.Features.StudentCourse.Queries
{
    public class GetTopGradesForCourseQuery : IGetTopGradesForCourseQuery
    {
        private readonly IQueryRepository<StudentCourseEntity> _queryRepository;

        public GetTopGradesForCourseQuery(IQueryRepository<StudentCourseEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<TopGradeDto>> ExecuteAsync(int courseId)
        {
            return await _queryRepository.GetAllQueryableInclude(sc => sc.CourseId == courseId,
                                                                sc => sc.Student,
                                                                sc => sc.Course)
                                                                .OrderByDescending(sc => sc.StudentGrade)
                                                                .Take(3)
                                                                .Select(sc => new TopGradeDto
                                                                {
                                                                    CourseName = sc.Course.Name,
                                                                    StudentName = sc.Student.Name,
                                                                    Grade = sc.StudentGrade
                                                                })
                                                                .ToListAsync();
        }
    }
}
