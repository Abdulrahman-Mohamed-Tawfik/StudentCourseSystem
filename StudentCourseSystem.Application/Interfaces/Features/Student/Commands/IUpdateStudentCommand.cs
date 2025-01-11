using StudentCourseSystem.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Student.Commands
{
    public interface IUpdateStudentCommand
    {
        Task ExecuteAsync(int id, StudentUpdateDto studentDto);
    }
}
