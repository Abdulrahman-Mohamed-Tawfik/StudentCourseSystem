using StudentCourseSystem.Application.Interfaces.Features.Course.Commands;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Repositories.Features.Course.Commands
{
    public class CreateCourseCommand : ICreateCourseCommand
    {
        private readonly ICommandRepository<CourseEntity> _commandRepository;

        public CreateCourseCommand(ICommandRepository<CourseEntity> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task ExecuteAsync(CourseCreateDto courseDto)
        {
            var course = new CourseEntity
            {
                Name = courseDto.Name,
                Description = courseDto.Description
            };

            await _commandRepository.CreateAsync(course);
            await _commandRepository.SaveChangesAsync();
        }
    }
}
