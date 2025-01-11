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
    public class GetTopGradesForAllCourses : IGetTopGradesForAllCourses
    {
        private readonly IQueryRepository<StudentCourseEntity> _queryRepository;
        public GetTopGradesForAllCourses(IQueryRepository<StudentCourseEntity> queryRepository)
        {
            _queryRepository = queryRepository;
        }
        public async Task<IEnumerable<TopGradeDto>> ExecuteAsync()
        {
            return await _queryRepository.GetAllQueryableInclude(null, sc => sc.Student, sc => sc.Course)
                                                                .OrderByDescending(sc => sc.StudentGrade)
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
