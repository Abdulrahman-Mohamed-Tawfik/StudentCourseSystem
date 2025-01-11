using StudentCourseSystem.Application.Interfaces.Features.Student.Commands;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.DTOs.Students;
using StudentCourseSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseSystem.Application.Repositories.Features.Student.Commands
{
    public class UpdateStudentCommand : IUpdateStudentCommand
    {
        private readonly ICommandRepository<StudentEntity> _commandRepository;
        private readonly IQueryRepository<StudentEntity> _queryRepository;

        public UpdateStudentCommand(ICommandRepository<StudentEntity> commandRepository, IQueryRepository<StudentEntity> queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task ExecuteAsync(int id, StudentUpdateDto studentDto)
        {
            // Await the query and use FirstOrDefaultAsync for Entity Framework
            var query = await _queryRepository.GetAsync(s => s.Id == id);
            var student = await query.FirstOrDefaultAsync();

            if (student == null)
                throw new KeyNotFoundException($"Student with ID {id} not found.");

            // Update fields based on the provided DTO
            if (studentDto.Name != null)
                student.Name = studentDto.Name;
            if (studentDto.Email != null)
                student.Email = studentDto.Email;
            if (studentDto.Password != null)
                student.Password = studentDto.Password;
            if (studentDto.Gender != null)
                student.Gender = studentDto.Gender;

            // Save the changes
            await _commandRepository.SaveChangesAsync();
        }
    }
}
