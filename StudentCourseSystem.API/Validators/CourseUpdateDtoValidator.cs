using FluentValidation;
using StudentCourseSystem.API.DTOs;

namespace StudentCourseSystem.API.Validators
{
    public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
    {
        public CourseUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Name cannot exceed 255 characters")
                .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("Description cannot exceed 255 characters")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.CreditHours)
                .GreaterThan(0).WithMessage("Credit hours must be greater than 0")
                .When(x => x.CreditHours.HasValue);
        }
    }
}
