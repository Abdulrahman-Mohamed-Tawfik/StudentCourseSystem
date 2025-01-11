using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.Application.Interfaces.Features.Course.Commands
{
    public interface IDeleteCourseCommand
    {
        Task<bool> ExecuteAsync(int courseId);
    }
}
