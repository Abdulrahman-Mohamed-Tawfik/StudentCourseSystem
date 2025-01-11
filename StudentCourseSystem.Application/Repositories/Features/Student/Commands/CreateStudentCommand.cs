using StudentCourseSystem.Application.Interfaces.Features.Student.Commands;
using StudentCourseSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentCourseSystem.Domain.Models;

namespace StudentCourseSystem.Application.Repositories.Features.Student.Commands
{
    public class CreateStudentCommand : ICreateStudentCommand
    {
        private readonly ICommandRepository<StudentEntity> _commandRepository;

        public CreateStudentCommand(ICommandRepository<StudentEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<StudentEntity> ExecuteAsync(StudentEntity student)
        {
            return await _commandRepository.CreateAsync(student);
        }
    }
}
