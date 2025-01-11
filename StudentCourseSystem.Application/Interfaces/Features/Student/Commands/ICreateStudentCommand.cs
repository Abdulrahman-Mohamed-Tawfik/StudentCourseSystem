using StudentCourseSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Student.Commands
{
    public interface ICreateStudentCommand
    {
        Task<StudentEntity> ExecuteAsync(StudentEntity student);
    }
}
