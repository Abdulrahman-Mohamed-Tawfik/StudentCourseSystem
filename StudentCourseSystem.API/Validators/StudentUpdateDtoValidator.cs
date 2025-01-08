using FluentValidation;
using StudentCourseSystem.API.DTOs;

namespace StudentCourseSystem.API.Validators
{
    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Name cannot exceed 255 characters");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .When(x => !string.IsNullOrEmpty(x.Password));

            RuleFor(x => x.Gender)
                .Must(g => g == 'M' || g == 'F').WithMessage("Gender must be 'M' or 'F'")
                .When(g => g.Gender != '\0');

        }
    }
}
