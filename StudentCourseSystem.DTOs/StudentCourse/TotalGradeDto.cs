using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseSystem.DTOs.StudentCourse
{
    public class TotalGradeDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public float TotalGrade { get; set; }
    }
}
