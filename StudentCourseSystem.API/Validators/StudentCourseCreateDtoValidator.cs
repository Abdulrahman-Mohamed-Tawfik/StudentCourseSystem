using FluentValidation;
using StudentCourseSystem.DTOs.StudentCourse;

namespace StudentCourseSystem.API.Validators
{
    public class StudentCourseCreateDtoValidator : AbstractValidator<StudentCourseCreateDto>
    {
        public StudentCourseCreateDtoValidator()
        {
            RuleFor(x => x.StudentId).GreaterThan(0).WithMessage("StudentId must be greater than 0.");
            RuleFor(x => x.CourseId).GreaterThan(0).WithMessage("CourseId must be greater than 0.");
            RuleFor(x => x.StudentGrade).InclusiveBetween(0, 100).WithMessage("StudentGrade must be between 0 and 100.");
        }
    }
}
