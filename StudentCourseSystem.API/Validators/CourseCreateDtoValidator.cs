using FluentValidation;
using StudentCourseSystem.API.DTOs;

namespace StudentCourseSystem.API.Validators
{
    public class CourseCreateDtoValidator : AbstractValidator<CourseCreateDto>
    {
        public CourseCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(120).WithMessage("Name cannot exceed 120 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters");

            RuleFor(x => x.CreditHours)
                .GreaterThan(0).WithMessage("Credit hours must be greater than 0");
        }
    }
}
