using StudentCourseSystem.Application.Interfaces.Features.Course.Commands;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories.Features.Course.Commands
{
    public class DeleteCourseCommand : IDeleteCourseCommand
    {
        private readonly ICommandRepository<CourseEntity> _commandRepository;

        public DeleteCourseCommand(ICommandRepository<CourseEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<bool> ExecuteAsync(int courseId)
        {
            return await _commandRepository.DeletePhysicallyAsync(courseId);
        }
    }
}
