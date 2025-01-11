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
    public class DeleteStudentCommand : IDeleteStudentCommand
    {
        private readonly ICommandRepository<StudentEntity> _commandRepository;

        public DeleteStudentCommand(ICommandRepository<StudentEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<bool> ExecuteAsync(int studentId)
        {
            return await _commandRepository.DeletePhysicallyAsync(studentId);
        }
    }
}
