using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Commands;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories.Features.StudentCourse.Commands
{
    public class CreateStudentCourseCommand : ICreateStudentCourseCommand
    {
        private readonly ICommandRepository<StudentCourseEntity> _commandRepository;
        public CreateStudentCourseCommand(ICommandRepository<StudentCourseEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<StudentCourseEntity> ExecuteAsync(StudentCourseEntity studentCourse)
        {
            return await _commandRepository.CreateAsync(studentCourse);
        }
    }
}
