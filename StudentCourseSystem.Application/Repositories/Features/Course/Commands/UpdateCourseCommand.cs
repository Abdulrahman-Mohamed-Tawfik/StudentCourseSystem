using StudentCourseSystem.Application.Interfaces.Features.Course.Commands;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Courses;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseSystem.Application.Repositories.Features.Course.Commands
{
    public class UpdateCourseCommand : IUpdateCourseCommand
    {
        private readonly ICommandRepository<CourseEntity> _commandRepository;
        private readonly IQueryRepository<CourseEntity> _queryRepository;

        public UpdateCourseCommand(ICommandRepository<CourseEntity> commandRepository, IQueryRepository<CourseEntity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task ExecuteAsync(int id, CourseUpdateDto courseDto)
        {
            var query = await _queryRepository.GetAsync(c => c.Id == id);
            var course = await query.FirstOrDefaultAsync();

            if (course == null)
                throw new KeyNotFoundException($"Course with ID {id} not found.");

            // Update fields
            if (courseDto.Name != null)
                course.Name = courseDto.Name;
            if (courseDto.Description != null)
                course.Description = courseDto.Description;

            await _commandRepository.SaveChangesAsync();
        }
    }
}
