using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.DTOs.StudentCourse
{
    public class StudentCourseCreateDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public float? StudentGrade { get; set; }
    }
}
